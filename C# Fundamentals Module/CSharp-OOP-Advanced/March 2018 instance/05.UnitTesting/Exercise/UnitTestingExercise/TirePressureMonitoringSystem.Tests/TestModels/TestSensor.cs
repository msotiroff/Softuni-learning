namespace TirePressureMonitoringSystem.Tests.TestModels
{
    public class TestSensor : Sensor
    {
        private double pressureValue;

        public TestSensor(double pressureValue)
        {
            this.pressureValue = pressureValue;
        }

        public new double PopNextPressurePsiValue()
        {
            return this.pressureValue;
        }
    }
}
