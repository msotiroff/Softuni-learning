using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
