namespace WizMail.Services.Contracts
{
    using System.Collections.Generic;
    using WizMail.Services.Models.Email;

    public interface IEmailService
    {
        WholeMailBoxServiceModel GetByUserId(int id);

        bool ProcessEmail(int senderId, string title, string message, string attachment, IEnumerable<string> recipients, bool forSending);

        EmailDetailsServiceModel GetById(int id);

        void Read(int id);
    }
}
