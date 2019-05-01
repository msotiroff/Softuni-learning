using System;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
    {
        Console.WriteLine(obj);
    }
}
