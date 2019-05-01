namespace SoftUniClone.Services.Implementations
{
    using Contracts;
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System.IO;

    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GeneratePdfFromHtl(string html)
        {
            Document pdf = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HtmlWorker htmlParser = new HtmlWorker(pdf);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdf, memoryStream);

                pdf.Open();

                using (StringReader streamReader = new StringReader(html))
                {
                    htmlParser.Parse(streamReader);
                }

                pdf.Close();

                byte[] bytes = memoryStream.ToArray();

                return bytes;
            }
        }
    }
}