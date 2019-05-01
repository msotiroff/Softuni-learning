using System;

namespace _6.Boolean_Variable
{
    class BooleanVariable
    {
        static void Main(string[] args)
        {
            string variable = Console.ReadLine();

            bool trueOrFalse =  Convert.ToBoolean(variable);

            Console.WriteLine(trueOrFalse ? "Yes" : "No");
        }
    }
}
