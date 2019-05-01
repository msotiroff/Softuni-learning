namespace MvcFramework.Routers
{
    using System.IO;
    using System.Linq;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ResourceRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            IHttpResponse fileResponse = null;

            var fileFullName = request.Path.Split('/').Last();
            var fileExtension = request.Path.Split('.').Last();

            try
            {
                var fileContent = this.ReadFileContent(fileFullName, fileExtension);

                fileResponse = new FileResponse(HttpStatusCode.Found, fileContent);
            }
            catch
            {
                return new NotFoundResponse();
            }

            return fileResponse;
        }

        private byte[] ReadFileContent(string fileFullName, string fileExtension)
        {
            var filePath = string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ResoursesFolder,
                fileExtension,
                fileFullName);

            var byteContent = File.ReadAllBytes(filePath);

            return byteContent;
        }
    }
}
