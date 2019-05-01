using System.Collections.Generic;

namespace Tweeter.Models.Contracts
{
    public interface IClient
    {
        IReadOnlyList<ITweet> Tweeters { get; }

        string Tweet(ITweet tweeter);

        string GetCurrentTweeter();
    }
}
