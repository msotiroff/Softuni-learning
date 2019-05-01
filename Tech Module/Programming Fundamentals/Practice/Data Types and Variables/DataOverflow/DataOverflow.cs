using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOverflow
{
    class DataOverflow
    {
        static void Main(string[] args)
        {
            ulong num1 = ulong.Parse(Console.ReadLine());
            ulong num2 = ulong.Parse(Console.ReadLine());
            
            ulong bigger = Math.Max(num1, num2);
            ulong smaller = Math.Min(num1, num2);

            string typeOfBigger = null;
            string typeOfSmaller = null;
            
            double overFlow = 0.0;
            if (bigger <= 255)
            {
                typeOfBigger = "byte";
            }
            else if (bigger > 255 && bigger <= 65535)
            {
                typeOfBigger = "ushort";
            }
            else if (bigger > 65535 && bigger <= 4294967295)
            {
                typeOfBigger = "uint";
            }
            else if (bigger > 4294967295 && bigger <= 18446744073709551615)
            {
                typeOfBigger = "ulong";
            }

            if (smaller <= 255)
            {
                typeOfSmaller = "byte";
                overFlow = (double)bigger / 255;
            }
            else if (smaller > 255 && smaller <= 65535)
            {
                typeOfSmaller = "ushort";
                overFlow = (double)bigger / 65535;
            }
            else if (smaller > 65535 && smaller <= 4294967295)
            {
                typeOfSmaller = "uint";
                overFlow = (double)bigger / 4294967295;
            }
            else if (smaller > 4294967295 && smaller <= 18446744073709551615)
            {
                typeOfSmaller = "ulong";
                overFlow = (double)bigger / 18446744073709551615;
            }

                Console.WriteLine("bigger type: {0}", typeOfBigger);
                Console.WriteLine("smaller type: {0}", typeOfSmaller);
                Console.WriteLine("{0} can overflow {1} {2} times", bigger, typeOfSmaller, Math.Round(overFlow));
          
        }
    }
}

