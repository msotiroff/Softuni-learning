namespace P01.JediMeditation
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main(string[] args)
        {
            var isMasterYodaMethodizeMeditation = false;

            var masters = new List<string>();
            var knights = new List<string>();
            var padawans = new List<string>();
            var impudents = new List<string>();

            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var jedis = Console.ReadLine().Split();

                foreach (var jedi in jedis)
                {
                    var identifier = jedi[0];

                    switch (identifier)
                    {
                        case 'm':
                            masters.Add(jedi);
                            break;
                        case 'k':
                            knights.Add(jedi);
                            break;
                        case 'p':
                            padawans.Add(jedi);
                            break;
                        case 's':
                        case 't':
                            impudents.Add(jedi);
                            break;
                        case 'y':
                            isMasterYodaMethodizeMeditation = true;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (isMasterYodaMethodizeMeditation)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    string.Join(" ", masters),
                    string.Join(" ", knights),
                    string.Join(" ", impudents),
                    string.Join(" ", padawans));
            }
            else
            {
                Console.WriteLine("{0} {1} {2} {3}",
                    string.Join(" ", impudents),
                    string.Join(" ", masters),
                    string.Join(" ", knights),
                    string.Join(" ", padawans));
            }
        }
    }
}
