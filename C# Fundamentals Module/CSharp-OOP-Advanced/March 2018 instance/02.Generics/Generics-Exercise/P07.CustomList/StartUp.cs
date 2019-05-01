using System;

class StartUp
{
    static void Main(string[] args)
    {
        var elements = new CustomList<string>();

        var commandReader = new CommandReader(elements);
        commandReader.StartReadingCommands();
    }
}
