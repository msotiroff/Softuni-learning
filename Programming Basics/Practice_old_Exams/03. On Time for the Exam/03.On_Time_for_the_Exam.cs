using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinute = int.Parse(Console.ReadLine());
            int studentArrivesHour = int.Parse(Console.ReadLine());
            int studentArrivesMinute = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMinute;
            int studentTime = studentArrivesHour * 60 + studentArrivesMinute;
            int difference = Math.Abs(examTime - studentTime);
            int diffHour = (int)(difference / 60);
            int diffMinutes = (int)(difference - diffHour * 60);

            if (studentTime > examTime)
            {
                Console.WriteLine("Late");
                if (difference < 60)
                {
                    Console.WriteLine($"{diffMinutes} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{diffHour}:{diffMinutes:00} hours after the start");
                }
            }
            else if (studentTime + 30 >= examTime)
            {
                Console.WriteLine("On time");
                if (difference == 0)
                {
                    return;
                }
                if (difference < 60)
                {
                    Console.WriteLine($"{diffMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{diffHour}:{diffMinutes:00} hours before the start");
                }
            }
            else if (studentTime + 30 < examTime)
            {
                Console.WriteLine("Early");
                if (difference < 60)
                {
                    Console.WriteLine($"{diffMinutes} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{diffHour}:{diffMinutes:00} hours before the start");
                }
            }



        }
    }
}
