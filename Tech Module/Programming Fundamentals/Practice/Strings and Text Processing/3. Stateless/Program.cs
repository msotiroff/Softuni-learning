using System;

namespace _3.Stateless
{
    class Program
    {
        static void Main(string[] args)
        {
            string state = Console.ReadLine();
            string fiction = Console.ReadLine();

            while (state != "collapse")
            {
                while (fiction.Length > 0)
                {
                    while(state.Contains(fiction))
                    {
                        int indexOfFound = state.IndexOf($"{fiction}");
                        int fictionLenght = fiction.Length;
                        state = state.Remove(indexOfFound, fictionLenght);
                    }
                    if (state == string.Empty)
                    {
                        Console.WriteLine("(void)");
                        break;
                    }

                    if (fiction.Length >= 2)
                    {
                        fiction = fiction.Remove(0, 1);
                        fiction = fiction.Remove(fiction.Length - 1);
                    }
                    else
                    {
                        fiction = string.Empty;
                    }
                    if (fiction.Length == 0)
                    {
                        Console.WriteLine(state.Trim());
                        break;
                    }
                }
                
                state = Console.ReadLine();
                if (state != "collapse")
                {
                    fiction = Console.ReadLine();
                }
            }

        }
    }
}
