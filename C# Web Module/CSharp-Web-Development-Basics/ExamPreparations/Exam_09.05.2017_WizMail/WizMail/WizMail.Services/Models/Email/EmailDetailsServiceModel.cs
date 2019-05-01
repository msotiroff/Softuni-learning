namespace WizMail.Services.Models.Email
{
    using AutoMapper;
    using System.Linq;
    using WizMail.Common.AutoMapping;
    using WizMail.Models;

    public class EmailDetailsServiceModel : IMapWith<Email>, IHaveCustomMapping
    {
        public string Title { get; set; }
        
        public string Message { get; set; }

        public string Attachment { get; set; }
        
        public string SenderEmailAddress { get; set; }
        
        public string Recipients { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Email, EmailDetailsServiceModel>()
                .ForMember(dest => dest.Recipients, opt 
                    => opt.MapFrom(sour 
                        => string.Join("; ", sour.Recipients.Select(r => r.Recipient.EmailAddress))))
                .ForAllOtherMembers(opt => opt.AllowNull());
        }
    }
}
