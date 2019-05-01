public abstract class Entity : IEntity
{
    protected Entity(string id)
    {
        this.Id = id;
    }
    
    public string Id { get; }
}
