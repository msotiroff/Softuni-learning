using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyEaster
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please enter egg size (best between 3 and 15):");
                var n = int.Parse(Console.ReadLine());
                var interval = 0;
                var deco = n + 2;
                var totalEven = 4 * n;
                var totalOdd = 4 * n + 1;
                interval = ((4 * n + 1) - n) / 2;
                Console.Write(new string(' ', interval));
                Console.WriteLine(new string('_', n));
                if (n % 2 != 0)
                {
                    interval = (totalOdd - deco) / 2;
                    for (int i = 0; i < (2 * n) - ((n - 2) / 2 + 3); i++)
                    {
                        Console.Write(new string(' ', interval));
                        interval--;
                        Console.WriteLine(new string('^', deco));
                        deco += 2;
                    }
                }
                else
                {
                    interval = (totalEven - deco) / 2;
                    for (int i = 0; i < (2 * n) - ((n - 2) / 2 + 3); i++)
                    {
                        Console.Write(new string(' ', interval));
                        interval--;
                        Console.WriteLine(new string('^', deco));
                        deco += 2;
                    }
                }
                Console.Write(new string(' ', interval));
                Console.Write("*");
                Console.Write(new string('_', deco - 2));
                Console.WriteLine("*");
                if (n % 2 != 0)
                {
                    for (int i = 0; i < n - 6; i++)
                    {
                        Console.Write(new string('+', totalOdd));
                        Console.WriteLine();
                    }
                }
                else
                {
                    for (int i = 0; i < n - 6; i++)
                    {
                        Console.Write(new string('+', totalEven));
                        Console.WriteLine();
                    }
                }
                Console.Write("|");
                Console.Write(new string('_', ((4 * n + 1) - 7) / 2));
                Console.Write("HAPPY");
                if (n % 2 != 0)
                {
                    Console.Write(new string('_', (totalOdd - 7) / 2));
                }
                else
                {
                    Console.Write(new string('_', (totalEven - 8) / 2));
                }
                Console.WriteLine("|");
                Console.Write("+");
                Console.Write(new string('~', ((4 * n + 1) - 9) / 2));
                Console.Write("EASTER!");
                if (n % 2 != 0)
                {
                    Console.Write(new string('~', (totalOdd - 9) / 2));
                }
                else
                {
                    Console.Write(new string('~', ((4 * n + 1) - 10) / 2));
                }
                Console.WriteLine("+");
                if (n % 2 != 0)
                {
                    for (int i = 0; i < n - 2; i++)
                    {
                        Console.Write(new string('+', totalOdd));
                        Console.WriteLine();
                    }
                }
                else
                {
                    for (int i = 0; i < n - 2; i++)
                    {
                        Console.Write(new string('+', totalEven));
                        Console.WriteLine();
                    }
                }
                if (n % 2 != 0)
                {
                    deco = totalOdd;
                    interval = (totalOdd - deco) / 2;
                    for (int i = n; i > 0; i--)
                    {
                        Console.Write(new string(' ', interval));
                        interval++;
                        Console.WriteLine(new string('*', deco));
                        deco -= 2;
                    }
                }
                else
                {
                    deco = totalEven;
                    interval = (totalEven - deco) / 2;
                    for (int i = n; i > 0; i--)
                    {
                        Console.Write(new string(' ', interval));
                        interval++;
                        Console.WriteLine(new string('*', deco));
                        deco -= 2;
                    }
                }
                Console.Write(new string(' ', interval));
                Console.Write("\\");
                Console.Write(new string('*', deco - 2));
                Console.WriteLine("/");
            }
        }
    }

