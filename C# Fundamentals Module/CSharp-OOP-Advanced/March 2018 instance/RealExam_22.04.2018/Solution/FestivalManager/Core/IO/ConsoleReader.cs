using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return System.Console.ReadLine();
        }
    }
}
