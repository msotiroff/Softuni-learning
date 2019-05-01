using System;

public class CombatLogger : Logger
{
    public override void Handle(LogType logType, string message)
    {
        if (logType == LogType.MAGIC || logType == LogType.ATTACK)
        {
            Console.WriteLine($"{logType.ToString()}: {message}");
        }

        this.PassToSuccessor(logType, message);
    }
}
