namespace ListIterator.Core
{
    using ListIterator.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        private bool isRunning;
        private ListIterator listIterator;

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                try
                {
                    var inputParams = Console.ReadLine().Split();

                    var commandName = inputParams.First();
                    var arguments = inputParams.Skip(1).ToArray();

                    string result = default(string);

                    switch (commandName)
                    {
                        case "END":
                            this.isRunning = false;
                            break;
                        case "Create":
                            this.listIterator = new ListIterator(arguments);
                            break;
                        case "Move":
                            result = this.listIterator.Move().ToString();
                            break;
                        case "HasNext":
                            result = this.listIterator.HasNext().ToString();
                            break;
                        case "Print":
                            result = this.listIterator.Print();
                            break;
                        default:
                            break;
                    }

                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                    }
                }
                catch (ArgumentNullException nullex)
                {
                    Console.WriteLine(nullex.ParamName);
                    Environment.Exit(0);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
