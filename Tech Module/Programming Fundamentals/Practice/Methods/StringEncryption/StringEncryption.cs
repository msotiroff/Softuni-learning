using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncryption
{
    class StringEncryption
    {
        public static void Main(string[] args)
        {
            //              8. * String Encryption


            //              Write a method Encrypt(char letter) which encrypts the letter in the following way:

            //              1)Take the first and the last digit of its ASCII code and append them together in a string.

            //              2) Append at the start of the resulting string the character corresponding to:

            //              - the ASCII code of the letter + the last digit of the ASCII code of the letter

            //              3) Then append at the end of the resulting string the character corresponding to:

            //              - the ASCII code of the letter - the first digit of the ASCII code of the letter

            //              4) The method should return the encrypted string.



            int n = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char currentCharacter = char.Parse(Console.ReadLine());
                string currentStringToAdd = EncryptString(currentCharacter);
                result += currentStringToAdd;
            }
            Console.WriteLine(result);

        }
        public static string EncryptString(char letter)
        {
            int charNumber = (int)(letter);
            int copyOfCharNumber = charNumber;
            int firstDigit = 0;
            int lastDigit = charNumber % 10;
            while (charNumber > 0)
            {
                firstDigit = charNumber % 10;
                charNumber /= 10;
            }
            char firstCharacter = (char)(copyOfCharNumber + lastDigit);
            char lastCharacter = (char)(copyOfCharNumber - firstDigit);
            string encryptedString = firstCharacter + firstDigit.ToString() + lastDigit.ToString() + lastCharacter;
            return encryptedString;
        }
    }
}
