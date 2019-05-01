using System;

public class EventLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        if (logType == LogType.EVENT)
        {
            Console.WriteLine($"{logType.ToString()}: {message}");
        }

        this.PassToSuccessor(logType, message);
    }
}
