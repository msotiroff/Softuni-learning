namespace CustomHttpServer.Server.Infrastructure.Extensions.CustomExceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionMsg = "Invalid request line!";

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException()
            : base(BadRequestExceptionMsg)
        {
        }
    }
}
