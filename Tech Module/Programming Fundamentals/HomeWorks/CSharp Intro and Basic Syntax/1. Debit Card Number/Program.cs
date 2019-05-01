using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Debit_Card_Number
{
    public class DebitCardNumber
    {
        public static void Main(string[] args)
        {
            string[] cardCodes = new string[4];

            for (int i = 0; i < 4; i++)
            {
                string currentInput = Console.ReadLine();
                while (currentInput.Length < 4)
                {
                    currentInput = "0" + currentInput;
                }
                cardCodes[i] = currentInput;
            }

            Console.WriteLine(string.Join(" ", cardCodes));
        }
    }
}
