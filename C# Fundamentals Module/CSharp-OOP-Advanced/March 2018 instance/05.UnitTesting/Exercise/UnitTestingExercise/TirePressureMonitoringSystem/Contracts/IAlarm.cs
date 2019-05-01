namespace TirePressureMonitoringSystem.Contracts
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check();
    }
}