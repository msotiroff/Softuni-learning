namespace Tweeter.Models
{
    using Contracts;
    using System;

    public class Tweet : ITweet
    {
        private const string ErrorMsg = "Message content can not be empty!";

        private string message;

        public Tweet(string message)
        {
            this.Message = message;
        }

        public string Message
        {
            get => this.message;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ErrorMsg);
                }

                this.message = value;
            }
        }
    }
}
