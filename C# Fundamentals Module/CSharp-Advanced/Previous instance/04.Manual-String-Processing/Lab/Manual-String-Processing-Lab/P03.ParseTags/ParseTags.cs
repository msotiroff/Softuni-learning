namespace P03.ParseTags
{
    using System;

    public class ParseTags
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            int indexOfOpenTag;
            while ((indexOfOpenTag = text.IndexOf("<upcase>")) != -1)
            {
                int indexOfCloseTag = text.IndexOf("</upcase>");
                if (indexOfCloseTag == -1)
                {
                    break;
                }

                var textToUpLength = indexOfCloseTag - indexOfOpenTag - 8;
                var uppedText = text.Substring(indexOfOpenTag + 8, textToUpLength).ToUpper();

                var textToBeReplaced = text.Substring(indexOfOpenTag, textToUpLength + 17);

                text = text.Replace(textToBeReplaced, uppedText);
            }

            Console.WriteLine(text);
        }
    }
}
