namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyRegister<T>
    {
        int Count();
        T DequeueEmergency();
        void EnqueueEmergency(T emergency);
        bool IsEmpty();
        T PeekEmergency();
    }
}