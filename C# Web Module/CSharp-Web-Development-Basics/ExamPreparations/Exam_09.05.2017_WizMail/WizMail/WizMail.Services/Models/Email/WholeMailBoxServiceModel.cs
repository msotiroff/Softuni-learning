namespace WizMail.Services.Models.Email
{
    using System.Collections.Generic;

    public class WholeMailBoxServiceModel
    {
        public WholeMailBoxServiceModel()
        {
            this.Inbox = new HashSet<MailBoxItemServiceModel>();
            this.Other = new HashSet<MailBoxItemServiceModel>();
        }

        public IEnumerable<MailBoxItemServiceModel> Inbox { get; set; }

        public IEnumerable<MailBoxItemServiceModel> Other { get; set; }
    }
}
