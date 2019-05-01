using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.ParkingValidation
{
    class ParkingValidation
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingUserDataBase =
                new Dictionary<string, string>();

            string patternLPN = @"\b[A-Z]{2}[0-9]{4}[A-Z]{2}\b";
            Regex searchedLPN = new Regex(patternLPN);

            int numberOfLogs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLogs; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string command = input[0];
                string name = input[1];
                if (command == "register")
                {
                    string licenseNumber = input[2];
                    var matched = searchedLPN.Match(licenseNumber);

                    {
                        if (parkingUserDataBase.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {parkingUserDataBase[name]}");
                        }
                        else if (parkingUserDataBase.ContainsValue(licenseNumber))
                        {
                            Console.WriteLine($"ERROR: license plate {licenseNumber} is busy");
                        }
                        else
                        {
                            if (matched.Success)
                            {
                                parkingUserDataBase.Add(name, licenseNumber);
                                Console.WriteLine($"{name} registered {licenseNumber} successfully");
                            }
                            else
                            {
                                Console.WriteLine($"ERROR: invalid license plate {licenseNumber}");
                            }
                        }
                    }
                    
                }
                else if (command == "unregister")
                {
                    if (!parkingUserDataBase.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        Console.WriteLine($"user {name} unregistered successfully");
                        parkingUserDataBase.Remove(name);
                    }
                }
            }

            if (parkingUserDataBase.Count > 0)
            {
                foreach (var user in parkingUserDataBase)
                {
                    Console.WriteLine($"{user.Key} => {user.Value}");
                }
            }

        }
    }
}
