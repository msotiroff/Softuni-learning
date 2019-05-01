using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Decode_Radio_Frequencies
{
    class Program
    {
        static void Main(string[] args)
        {
            //You are given an array of doubles(one line, space - separated).
            //Your task is to convert the double values to their character representations
            //and insert them into a list like so:
            //Example: 83.105
            //Extract the left part of the number and convert it to its ASCII code representation: 83  S
            //Extract the right part of the number and convert I to its ASCII code representation: 105  i
            //Insert the left character at the position equal to the index of the double number in the original array.
            // Index of double: 0  insert S at index 0
            //Insert the right character at the position equal to the index of the double number 
            //in the original array, counted in reverse: index of the double: 0
            // insert “i” at index 0, counted in reverse(so, the end of the list)

            //Repeat the aforementioned algorithm for each element of the double array,
            //until you run out of elements.When you do, print the list with no delimiter. 
            //If any of the parts of the double number are 0(such as 86.0 or 0.97), 
            //ignore them and do not insert them anywhere.

            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay).

            string[] values = Console.ReadLine().Split(' ').ToArray();

            List<char> result = new List<char>();

            int leftPart = 0;
            int rightPart = 0;

            for (int i = 0; i < values.Length; i++)
            {
                string[] currentNumber = values[i].Split('.');
                leftPart = int.Parse(currentNumber[0]);
                rightPart = int.Parse(currentNumber[1]);

                char leftNumRepresentation = (char)leftPart;
                char rightNumRepresentation = (char)rightPart;

                if (leftPart > 0)
                {
                    result.Insert(i, leftNumRepresentation);
                }
                if (rightPart > 0)
                {
                    result.Insert(result.Count - 1 - i, rightNumRepresentation);
                }
                
            }

            for (int i = 0; i < result.Count / 2; i++)
            {
                int listLenght = result.Count;
                char currentCharacter = result[i];
                result[i] = result[listLenght - i - 1];
                result[listLenght - i - 1] = currentCharacter;
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();
        }
    }
}
