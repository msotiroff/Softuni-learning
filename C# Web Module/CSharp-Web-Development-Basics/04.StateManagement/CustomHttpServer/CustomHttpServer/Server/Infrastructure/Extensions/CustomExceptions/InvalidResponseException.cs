namespace CustomHttpServer.Server.Infrastructure.Extensions.CustomExceptions
{
    using System;

    public class InvalidResponseException : Exception
    {
        private const string InvalidResponseErrorMsg = "Invalid Response";

        public InvalidResponseException()
            :base(InvalidResponseErrorMsg)
        {
        }

        public InvalidResponseException(string message)
            : base(message)
        {
        }
    }
}
