namespace InfernoInfinity.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string text);

        void WriteLine(object obj);

        void WriteLine();
    }
}
