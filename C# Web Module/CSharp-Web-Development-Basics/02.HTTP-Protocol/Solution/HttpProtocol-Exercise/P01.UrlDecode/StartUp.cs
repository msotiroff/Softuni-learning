namespace P01.UrlDecode
{
    using System;
    using System.Net;

    public class StartUp
    {
        public static void Main()
        {
            var inputUrl = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(inputUrl);

            Console.WriteLine(decodedUrl);
        }
    }
}
