namespace Employees.App.Interfaces
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
