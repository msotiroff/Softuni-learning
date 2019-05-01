namespace DateTime.Tests
{
    using DateTimeExtenssions;
    using NUnit.Framework;
    using Moq;
    using System;

    public class DateTimeTests
    {
        private Mock<IDateTime> mockedDateTime;

        [SetUp]
        public void InitializeDateTime()
        {
            this.mockedDateTime = new Mock<IDateTime>();
        }

        [Test]
        public void DateTimeShouldReturnCorrectDate()
        {
            this.mockedDateTime
                .Setup(d => d.Now)
                .Returns(DateTime.Now);

            var actual = DateTime.Now.ToShortDateString();
            var expected = this.mockedDateTime.Object.Now.ToShortDateString();

            var errorMsg = $"Method did not return the correct value. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void DateTimeShouldReturnCorrectTime()
        {
            this.mockedDateTime
                .Setup(d => d.Now)
                .Returns(DateTime.Now);

            var actual = DateTime.Now.ToShortTimeString();
            var expected = this.mockedDateTime.Object.Now.ToShortTimeString();

            var errorMsg = $"Method did not return the correct value. Expected: {expected}, actual: {actual}";

            Assert.AreEqual(expected, actual, errorMsg);
        }

        [Test]
        public void AddDayInMiddleOfMonthShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(2018, 04, 7));

            DateTime dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(1);

            Assert.AreEqual(8, dateTime.Day);
        }

        [Test]
        public void AddDayAndChangeMonthShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(2018, 03, 31));
            
            var dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(1);
            
            Assert.AreEqual(1, dateTime.Day);
            Assert.AreEqual(4, dateTime.Month);
        }

        [Test]
        public void AddNegativeDaysShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(2018, 04, 07));
            
            var dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(-5);
            
            Assert.AreEqual(4, dateTime.Month);
            Assert.AreEqual(2, dateTime.Day);
        }

        [Test]
        public void AddNegativeDaysAndChangeMonthShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(2018, 04, 01));
            
            var dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(-1);
            
            Assert.AreEqual(31, dateTime.Day);
            Assert.AreEqual(3, dateTime.Month);
        }

        [Test]
        public void AddDayToLeapYearFebruaryShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(1984, 02, 28));
            
            DateTime dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(1);
            
            Assert.AreEqual(29, dateTime.Day);
            Assert.AreEqual(2, dateTime.Month);
        }

        [Test]
        public void AddDayToNonLeapYearFebruaryShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(new DateTime(2018, 02, 28));
            
            DateTime dateTime = this
                .mockedDateTime
                .Object
                .Now
                .AddDays(1);
            
            Assert.AreEqual(1, dateTime.Day);
            Assert.AreEqual(3, dateTime.Month);
        }

        [Test]
        public void AddDayToDateTimeMinValueShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(DateTime.MinValue);
            
            Assert.DoesNotThrow(() => this
            .mockedDateTime
            .Object
            .Now
            .AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMinValueShouldThrowException()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(DateTime.MinValue);
            
            Assert
                .Throws<ArgumentOutOfRangeException>(() => 
                    this.mockedDateTime.Object.Now.AddDays(-1));
        }

        [Test]
        public void AddDayToDateTimeMaxValueShouldThrowException()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(DateTime.MaxValue);
            
            Assert
                .Throws<ArgumentOutOfRangeException>(() => 
                    this.mockedDateTime.Object.Now.AddDays(1));
        }

        [Test]
        public void SubtractDayToDateTimeMaxValueShouldWorkProperly()
        {
            this.mockedDateTime
                .Setup(x => x.Now)
                .Returns(DateTime.MaxValue);
            
            Assert
                .DoesNotThrow(() => 
                    this.mockedDateTime.Object.Now.AddDays(-1));
        }
    }
}
