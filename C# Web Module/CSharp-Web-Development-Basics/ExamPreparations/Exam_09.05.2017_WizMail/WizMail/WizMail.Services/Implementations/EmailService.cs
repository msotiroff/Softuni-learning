namespace WizMail.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WizMail.Data;
    using WizMail.Models;
    using WizMail.Models.Common;
    using WizMail.Services.Models.Email;

    public class EmailService : DataAccessService, IEmailService
    {
        public EmailService(WizMailDbContext db)
            : base(db)
        {
        }

        public EmailDetailsServiceModel GetById(int id)
        {
            var email = this.db
                .Emails
                .Where(e => e.Id == id)
                .ProjectTo<EmailDetailsServiceModel>()
                .FirstOrDefault();
            
            return email;
        }

        public void Read(int id)
        {
            var email = this.db.Emails.Find(id);
            if (email != null)
            {
                email.Flag = this.db.Flags.First(f => f.Name == ValidFlags.Read.ToString());
                this.db.Emails.Update(email);
                this.db.SaveChanges();
            }
        }

        public WholeMailBoxServiceModel GetByUserId(int userId)
        {
            var other = this.db
                .Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.SentEmails)
                .ProjectTo<MailBoxItemServiceModel>()
                .ToArray();

            var inbox = this.db
                .Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.RecievedEmails.Select(ue => ue.Email))
                .ProjectTo<MailBoxItemServiceModel>()
                .Where(e => e.Flag.Name == ValidFlags.Sent.ToString() || e.Flag.Name == ValidFlags.Read.ToString())
                .ToArray();

            var allEmails = new WholeMailBoxServiceModel
            {
                Inbox = inbox,
                Other = other,
            };

            return allEmails;
        }

        public bool ProcessEmail(int senderId, string title, string message, string attachment, IEnumerable<string> recipients, bool forSending)
        {
            recipients = recipients.Select(r => r.Split('@').First()).ToArray();

            var dbRecipients = this.db
                .Users
                .Where(u => recipients
                    .Contains(u.Username.ToLower()))
                .Select(u => new UserEmail { RecipientId = u.Id })
                .ToArray();

            if (!dbRecipients.Any())
            {
                return false;
            }

            var flagName = forSending ? ValidFlags.Sent.ToString() : ValidFlags.Draft.ToString();

            var email = new Email
            {
                SenderId = senderId,
                Title = title,
                Message = message,
                Attachment = attachment,
                FlagId = this.db.Flags.FirstOrDefault(f => f.Name == flagName).Id,
                Recipients = dbRecipients,
            };

            if (!this.ValidateModelState(email))
            {
                return false;
            }

            try
            {
                this.db.Emails.Add(email);
                this.db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
