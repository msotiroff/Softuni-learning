namespace HTTPServer.Http.Response
{
    using HTTPServer.Enums;
    using System;
    using System.IO;

    public class FileResponse : HttpResponse
    {
        public FileResponse(string path, string appDirectory)
        {
            this.StatusCode = HttpStatusCode.Ok;

            using (var streamReader = new StreamReader($@"../../../{appDirectory}" + path))
            {
                this.Content = streamReader.ReadToEnd();
            }
        }

        public string Content { get; set; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + this.Content;
        }
    }
}
