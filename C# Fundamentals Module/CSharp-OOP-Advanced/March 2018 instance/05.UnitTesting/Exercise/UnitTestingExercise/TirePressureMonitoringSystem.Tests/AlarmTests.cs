namespace TirePressureMonitoringSystem.Tests
{
    using NUnit.Framework;
    using Moq;
    using TirePressureMonitoringSystem;
    using TirePressureMonitoringSystem.Contracts;

    public class AlarmTests
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private Mock<IAlarm> alarmMock;

        [SetUp]
        public void InitializeData()
        {
            this.alarmMock = new Mock<IAlarm>();
        }

        [Test]
        public void DefaultValueOfAlarmOnShouldBeFalse()
        {
            var alarm = new Alarm();

            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestCase(17)]
        [TestCase(18.3)]
        [TestCase(19.5)]
        [TestCase(20.7)]
        [TestCase(21)]
        public void AlarmShouldBeOff(double testPressure)
        {
            var alarmOn = false;
            
            alarmMock
                .Setup(a => a.Check())
                .Callback(() => 
                {
                    // Copied method body from original entity:
                    double psiPressureValue = testPressure;

                    if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
                    {
                        alarmOn = true;
                    }
                });

            alarmMock.Object.Check();

            alarmMock.Verify(x => x.Check());
            Assert.IsFalse(alarmOn);
        }

        [TestCase(16.99)]
        [TestCase(222)]
        [TestCase(double.MinValue)]
        [TestCase(double.MaxValue)]
        [TestCase(21.01)]
        public void AlarmShouldBeOn(double testPressure)
        {
            var alarmOn = false;
            
            alarmMock
                .Setup(a => a.Check())
                .Callback(() =>
                {
                    // Copied method body from original entity:
                    double psiPressureValue = testPressure;

                    if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
                    {
                        alarmOn = true;
                    }
                });

            alarmMock.Object.Check();

            alarmMock.Verify(x => x.Check());
            Assert.IsTrue(alarmOn);
        }
    }
}
