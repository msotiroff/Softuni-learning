using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());
        
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == 'p')
            {
                hasMatch = true;

                int substringLenght = jump + 1;

                if (substringLenght + i > text.Length - 1)
                {
                    substringLenght = text.Length - i;
                }

                string matchedString = text.Substring(i, substringLenght);
                Console.WriteLine(matchedString);
                i += jump;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
