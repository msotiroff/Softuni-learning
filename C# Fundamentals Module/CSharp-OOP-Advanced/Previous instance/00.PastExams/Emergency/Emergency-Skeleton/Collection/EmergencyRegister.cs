using Emergency_Skeleton.Contracts;

public class EmergencyRegister<T> : IEmergencyRegister<T>
{
    private const int InitilSize = 16;

    private T[] emergencyQueue;
    private int currentSize;
    private int nextIndex;

    public EmergencyRegister()
    {
        this.emergencyQueue = new T[InitilSize];
        this.currentSize = 0;
        this.nextIndex = 0;
    }

    public void EnqueueEmergency(T emergency)
    {
        this.CheckIfResizeNeeded();

        this.emergencyQueue[this.nextIndex] = emergency;
        this.IncrementNextIndex();

        this.IncrementCurrentSize();
    }

    public T DequeueEmergency()
    {
        T removedElement = this.emergencyQueue[0];

        for (int i = 0; i < this.currentSize - 1; i++)
        {
            this.emergencyQueue[i] = this.emergencyQueue[i + 1];
        }

        this.DecrementNextIndex();
        this.DecrementCurrentSize();

        return removedElement;
    }

    public T PeekEmergency()
    {
        T peekedElement = this.emergencyQueue[0];

        return peekedElement;
    }

    private void CheckIfResizeNeeded()
    {
        if (this.currentSize == this.emergencyQueue.Length)
        {
            this.Resize();
        }
    }

    private void Resize()
    {
        T[] newArray = new T[this.currentSize * 2];

        for (int i = 0; i < this.currentSize; i++)
        {
            newArray[i] = this.emergencyQueue[i];
        }

        this.emergencyQueue = newArray;
    }

    public bool IsEmpty()
    {
        return this.currentSize == 0;
    }

    public int Count()
    {
        return this.currentSize;
    }

    private void IncrementNextIndex()
    {
        this.nextIndex++;
    }

    private void DecrementNextIndex()
    {
        this.nextIndex--;
    }

    private void IncrementCurrentSize()
    {
        this.currentSize++;
    }

    private void DecrementCurrentSize()
    {
        this.currentSize--;
    }
}