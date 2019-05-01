namespace P03.CubicMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            string message;
            while ((message = Console.ReadLine()) != "Over!")
            {
                var charactersCount = int.Parse(Console.ReadLine());

                var pattern = $@"^\d*(?<msg>[A-Za-z]{{{charactersCount}}})[^A-Za-z]*$";

                var match = Regex.Match(message, pattern);
                
                if (match.Success)
                {
                    var result = new StringBuilder();
                    var msg = match.Groups["msg"].Value;
                    int msgLength = message.Length;

                    for (int i = 0; i < msgLength; i++)
                    {
                        if (char.IsDigit(message[i]))
                        {
                            var index = int.Parse(message[i].ToString());

                            if (index >= 0 && index < msg.Length)
                            {
                                result.Append(msg[index]);
                            }
                            else
                            {
                                result.Append(" ");
                            }
                        }
                    }

                    Console.WriteLine($"{msg} == {result}");
                }
            }
        }
    }
}
