namespace WebServer.Http.Response
{
    using WebServer.Enums;
    using WebServer.Exceptions;

    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData)
        {
            this.ValidateStatusCode(statusCode);

            this.StatusCode = statusCode;
            this.FileData = fileData;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
        }

        public byte[] FileData { get; }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            int statusCodeNumber = (int)statusCode;

            if (statusCodeNumber < 300 && statusCodeNumber <= 399)
            {
                throw new InvalidResponseException("File responses need a status code above 300 and below 400!");
            }
        }
    }
}
