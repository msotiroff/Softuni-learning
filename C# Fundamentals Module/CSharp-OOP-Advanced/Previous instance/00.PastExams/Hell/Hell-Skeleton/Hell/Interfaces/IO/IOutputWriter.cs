public interface IOutputWriter
{
    void WriteLine(string format, params string[] args);

    void WriteLine(string line);
}
