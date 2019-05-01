namespace CustomHttpServer.Server.Infrastructure.Extensions.CustomExceptions
{
    using System;

    public class InvalidRequestMethodException : BadRequestException
    {
        private const string ErrorMsg = "Invalid request method!";

        public InvalidRequestMethodException(string message)
            : base(message)
        {
        }

        public InvalidRequestMethodException()
            : base(ErrorMsg)
        {
        }
    }
}
