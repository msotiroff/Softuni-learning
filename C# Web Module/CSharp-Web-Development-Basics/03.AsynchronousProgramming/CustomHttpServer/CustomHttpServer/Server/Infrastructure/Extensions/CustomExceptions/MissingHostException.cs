namespace CustomHttpServer.Server.Infrastructure.Extensions.CustomExceptions
{
    public class MissingHostException : BadRequestException
    {
        private const string ErrorMsg = "Host missing!";

        public MissingHostException()
            : base(ErrorMsg)
        {
        }

        public MissingHostException(string message) 
            : base(message)
        {
        }
    }
}
