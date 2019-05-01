namespace WizMail.Services.Models.Email
{
    using System;
    using System.Collections.Generic;
    using WizMail.Common.AutoMapping;
    using WizMail.Models;

    public class MailBoxItemServiceModel : IMapWith<Email>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Message { get; set; }

        public string Attachment { get; set; }
        
        public DateTime SendDate { get; set; }
        
        public string SenderEmailAddress { get; set; }

        public Flag Flag { get; set; }

        //public ICollection<UserEmail> Recipients { get; set; }
    }
}
