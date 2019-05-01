﻿namespace P03.RecursiveDrawing
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            Draw(n);
        }

        private static void Draw(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            Draw(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}
