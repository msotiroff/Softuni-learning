namespace WebServer.Http.Response
{
    using Common;
    using Enums;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileContents)
        {
            CoreValidator.ThrowIfNull(fileContents, nameof(fileContents));
            
            this.StatusCode = statusCode;
            this.FileData = fileContents;

            this.Headers.Add(HttpHeader.ContentLength, fileContents.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
        }

        public byte[] FileData { get; private set; }
    }
}
