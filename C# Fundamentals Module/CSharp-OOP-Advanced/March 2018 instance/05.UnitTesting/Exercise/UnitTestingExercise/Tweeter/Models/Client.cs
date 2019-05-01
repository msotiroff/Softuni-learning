namespace Tweeter.Models
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Client : IClient
    {
        private const string NoTweetsErrorMsg = "There aren't any tweets!";
        private const string TweetCannotBeNull = "Tweet cannot be null";

        private IList<ITweet> tweeters;

        public Client()
        {
            this.tweeters = new List<ITweet>();
        }

        public Client(IList<ITweet> tweeters)
        {
            this.tweeters = new List<ITweet>(tweeters);
        }

        public IReadOnlyList<ITweet> Tweeters => this.tweeters.ToList();

        public string GetCurrentTweeter()
        {
            if (this.Tweeters.Any())
            {
                return this.Tweeters.Last().Message;
            }

            throw new InvalidOperationException(NoTweetsErrorMsg);
        }

        public string Tweet(ITweet tweeter)
        {
            if (tweeter == null)
            {
                throw new InvalidOperationException(TweetCannotBeNull);
            }

            this.tweeters.Add(tweeter);

            return this.GetCurrentTweeter();
        }
    }
}
