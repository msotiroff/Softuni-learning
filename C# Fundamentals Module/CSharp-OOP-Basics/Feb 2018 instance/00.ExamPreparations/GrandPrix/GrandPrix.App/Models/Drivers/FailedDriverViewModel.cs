public class FailedDriverViewModel
{
    public FailedDriverViewModel(string name, string failureReason)
    {
        this.Name = name;
        this.FailureReason = failureReason;
    }
    
    public string Name { get; private set; }

    public string FailureReason { get; private set; }
}
