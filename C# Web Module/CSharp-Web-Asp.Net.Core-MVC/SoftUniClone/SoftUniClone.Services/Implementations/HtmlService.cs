namespace SoftUniClone.Services.Implementations
{
    using Contracts;
    using Ganss.XSS;

    public class HtmlService : IHtmlService
    {
        private readonly HtmlSanitizer htmlSanitizer;

        public HtmlService()
        {
            this.htmlSanitizer = new HtmlSanitizer();
            this.htmlSanitizer.AllowedAttributes.Add("class");
        }

        public string Sanitize(string html)
        {
            return this.htmlSanitizer.Sanitize(html);
        }
    }
}