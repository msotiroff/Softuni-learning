namespace Emergency_Skeleton.Contracts
{
    public interface IWriter
    {
        void WriteLine(string line);

        void AppendLine(string line);

        void WriteAllText();
    }
}
