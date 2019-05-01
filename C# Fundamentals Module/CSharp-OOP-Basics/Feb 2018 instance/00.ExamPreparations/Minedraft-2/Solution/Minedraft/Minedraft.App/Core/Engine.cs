using System;
using System.Linq;
using System.Text;

public class Engine : IEngine
{
    private bool isRunning;
    private IDraftManager draftManager;

    public Engine(IDraftManager draftManager)
    {
        this.draftManager = draftManager;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        var builder = new StringBuilder();

        while (this.isRunning)
        {
            string result = string.Empty;

            var commandParams = Console.ReadLine().Split();

            try
            {
                result = this.ProcessCommand(commandParams);
            }
            catch (Exception ex)
            {
                result = ex.InnerException.Message;
            }

            builder.AppendLine(result.Trim());
        }

        var finalResult = builder.ToString().Trim();
        
        Console.WriteLine(finalResult);
    }

    private string ProcessCommand(string[] commandParams)
    {
        var commandName = commandParams.First();

        this.isRunning = commandName != "Shutdown";

        var commanArgs = commandParams.Skip(1).ToList();

        var commandMethod = typeof(DraftManager)
            .GetMethods()
            .First(mi => mi.Name.ToLower() == commandName.ToLower());

        var paramsToPass = commanArgs.Count > 0
            ? new object[] { commanArgs }
            : null;

        var result = (string)commandMethod.Invoke(this.draftManager, paramsToPass);

        return result;
    }
}
