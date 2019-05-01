namespace RecyclingStation.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string output);

        void WriteLine(object obj);

        void AppendLine(string text);

        void WriteAllText();
    }
}
