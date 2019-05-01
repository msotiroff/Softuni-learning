public abstract class Worker : IWorker
{
    public string Id { get; protected set; }

    protected Worker(string id)
    {
        this.Id = id;
    }
}