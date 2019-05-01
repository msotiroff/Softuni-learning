namespace Tweeter.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using Tweeter.Models;
    using Tweeter.Models.Contracts;

    public class TweeterTests
    {
        private IClient client;
        private IList<ITweet> testTweeters;

        [SetUp]
        public void InitializeData()
        {
            this.testTweeters = new List<ITweet>
            {
                new Tweet("First msg"),
                new Tweet("Second msg"),
                new Tweet("Third msg")
            };

            this.client = new Client(this.testTweeters);
        }
        
        [TestCase(null)]
        [TestCase("")]
        public void TweetConstructorShouldThrowExceptionWhenArgumentIsNullOrEmpty(string message)
        {
            var errorMsg = "Expected exception has not been thrown!";

            Assert.That(() => new Tweet(message),
                Throws.ArgumentNullException,
                errorMsg);
        }

        [Test]
        public void TweetConstructorShouldWorkProperly()
        {
            var msg = "Some msg";
            ITweet tweet = new Tweet(msg);

            Assert.AreEqual(msg, tweet.Message);
        }

        [Test]
        public void TestClientConstructor()
        {
            for (int i = 0; i < this.testTweeters.Count; i++)
            {
                var actual = this.client.Tweeters[i];
                var expected = this.testTweeters[i];

                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void TweetMethodShouldAddTweetAndReturnCorrectMessage()
        {
            var msg = "Working properly!";

            var tweet = new Tweet(msg);
            var result = this.client.Tweet(tweet);

            var errorMsg = "The method did not return the correct message!";
            var tweetNotAdded = "Method did not add tweet to the collection!";

            Assert.AreEqual(msg, result, errorMsg);

            Assert.That(() => this.client.Tweeters.Last().Equals(tweet), tweetNotAdded);
        }

        [Test]
        public void TweetMethodShouldThrowExceptionIfArgumentIsNull()
        {
            var errorMsg = "Expected exception has not been thrown!";
            
            Assert.That(() => this.client.Tweet(null),
                Throws.InvalidOperationException,
                errorMsg);
        }

        [Test]
        public void GetCurrentTweeterMethodShouldReturnCorrectMessage()
        {
            var expected = this.testTweeters.Last().Message;
            var actual = this.client.GetCurrentTweeter();
            var errorMsg = "The method did not return the correct message!";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void GetCurrentTweeterMethodShouldThrowExceptionIfCollectionEmpty()
        {
            this.client = new Client();
            var errorMsg = "Expected exception has not been thrown!";

            Assert.That(() => client.GetCurrentTweeter(),
                Throws.InvalidOperationException,
                errorMsg);
        }

        [Test]
        public void TestNumbersOfMessagesAfterAddingSeveralTweets()
        {
            int expected = this.client.Tweeters.Count + 3;
            
            this.client.Tweet(new Tweet("New tweet!"));
            this.client.Tweet(new Tweet("New tweet!"));
            this.client.Tweet(new Tweet("New tweet!"));

            int actual = this.client.Tweeters.Count;
            
            Assert.AreEqual(expected, actual);
        }
    }
}
