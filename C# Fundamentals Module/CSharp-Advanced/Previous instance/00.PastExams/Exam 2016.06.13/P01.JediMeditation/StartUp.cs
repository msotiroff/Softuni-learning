namespace P01.JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            var masters = new List<string>();
            var knights = new List<string>();
            var padawans = new List<string>();
            var malaperts = new List<string>();

            var yodaMasterMoveMalaperts = false;

            var countOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfLines; i++)
            {
                var jedis = Console.ReadLine().Split();

                foreach (var currentJedi in jedis)
                {
                    var jediType = currentJedi[0];

                    switch (jediType)
                    {
                        case 'm':
                            masters.Add(currentJedi);
                            break;
                        case 'k':
                            knights.Add(currentJedi);
                            break;
                        case 'p':
                            padawans.Add(currentJedi);
                            break;
                        case 't':
                            malaperts.Add(currentJedi);
                            break;
                        case 's':
                            malaperts.Add(currentJedi);
                            break;
                        case 'y':
                            yodaMasterMoveMalaperts = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            var result = new StringBuilder();

            if (yodaMasterMoveMalaperts)
            {
                result.Append(string.Join(" ", masters));
                result.Append(" ");
                result.Append(string.Join(" ", knights));
                result.Append(" ");
                result.Append(string.Join(" ", malaperts));
                result.Append(" ");
                result.Append(string.Join(" ", padawans));
            }
            else
            {
                result.Append(string.Join(" ", malaperts));
                result.Append(" ");
                result.Append(string.Join(" ", masters));
                result.Append(" ");
                result.Append(string.Join(" ", knights));
                result.Append(" ");
                result.Append(string.Join(" ", padawans));
            }

            Console.WriteLine(result);
        }
    }
}
