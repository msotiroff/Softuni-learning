namespace WizMail.App.Controllers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using WizMail.App.Infrastructure.Attributes;
    using WizMail.App.Models.Mail;
    using WizMail.Common.Notifications;
    using WizMail.Models.Common;
    using WizMail.Services.Contracts;
    using WizMail.Services.Models.Email;

    public class MailController : BaseController
    {
        private readonly IEmailService emailService;

        public MailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Box()
        {
            var wholeMail = this.emailService.GetByUserId(this.Identity.Id);

            var unreadMessages = wholeMail
                .Inbox
                .Where(e => e.Flag.Name == ValidFlags.Sent.ToString())
                .Count();

            this.Model["unread"] = unreadMessages != 0 ? $"({unreadMessages})" : string.Empty;

            this.Model["drafts"] = wholeMail
                .Other
                .Where(e => e.Flag.Name == ValidFlags.Draft.ToString())
                .Count()
                .ToString();

            this.Request.UrlParameters.TryGetValue("internalBox", out string internalBox);

            IEnumerable<MailBoxItemServiceModel> mailsToRender;
            if (!string.IsNullOrWhiteSpace(internalBox))
            {
                mailsToRender = wholeMail
                    .Other
                    .Where(e => string.Compare(e.Flag.Name, internalBox, true) == 0);
            }
            else
            {
                mailsToRender = wholeMail.Inbox;
            }

            this.Request.UrlParameters.TryGetValue("searchTerm", out string searchTerm);
            if (searchTerm != null)
            {
                mailsToRender = mailsToRender
                    .Where(e =>
                        e.Title.ToLower().Contains(searchTerm.ToLower())
                        || e.Message.ToLower().Contains(searchTerm.ToLower()));
            }

            this.Model["all-emails"] = this.BuildEmailBoxList(mailsToRender);
            
            return View();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Compose() => View();

        [HttpPost]
        [AuthorizedOnly]
        public IActionResult Compose(EmailCreateViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var recipients = model
                .Recipients
                .Split(new[] { ' ', ';' }, System.StringSplitOptions.RemoveEmptyEntries)
                .Select(r => r.ToLower())
                .ToArray();

            if (!recipients.Any())
            {
                this.ShowNotification("There is no any valid recipients in your form!");
                return View();
            }

            var success = false;
            if (model.Send != null)
            {
                success = this.emailService
                    .ProcessEmail(this.Identity.Id, model.Title, model.Message, model.Attachment, recipients, true);
            }
            else if (model.Save != null)
            {
                success = this.emailService
                    .ProcessEmail(this.Identity.Id, model.Title, model.Message, model.Attachment, recipients, false);
            }

            if (!success)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation);
                return View();
            }

            var operationMsg = model.Send != null 
                ? $"send to {recipients.Count()} recipients" 
                : "saved to Draft folder";

            this.ShowNotification($"Email successfully {operationMsg}!", NotificationType.success);
            return this.Box();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Details(int id)
        {
            var emailToBeDisplayed = this.emailService.GetById(id);

            if (emailToBeDisplayed == null)
            {
                this.ShowNotification("The email you are trying to view does not exist!");
                return this.Box();
            }

            this.emailService.Read(id);

            this.Model["sender"] = emailToBeDisplayed.SenderEmailAddress;
            this.Model["recipients"] = emailToBeDisplayed.Recipients;
            this.Model["title"] = emailToBeDisplayed.Title;
            this.Model["message"] = emailToBeDisplayed.Message;
            this.Model["attachment"] = emailToBeDisplayed.Attachment;

            return View();
        }

        private string BuildEmailBoxList(IEnumerable<MailBoxItemServiceModel> emails)
        {
            var builder = new StringBuilder();

            var template = File.ReadAllText(@"..\..\..\Views\Shared\EmailBoxRow.html");

            foreach (var email in emails)
            {
                var message = email.Message.Length > 100
                    ? email.Message.Substring(0, 100) + "..."
                    : email.Message;

                var status = email.Flag.Name == ValidFlags.Read.ToString()
                    ? "Read"
                    : email.Flag.Name == ValidFlags.Draft.ToString()
                        ? "Saved"
                        : "Unread";

                var row = string.Format(template,
                    email.Title,
                    message,
                    status,
                    email.SendDate.ToShortDateString(),
                    email.Id);

                builder.AppendLine(row);
            }

            return builder.ToString();
        }
    }
}
