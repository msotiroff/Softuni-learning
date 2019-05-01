using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.TrainersSalary
{
    class TrainersSalary
    {
        static void Main(string[] args)
        {
            int lessons = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double paymentPerLesson = budget / lessons;

            int jelev = 0;
            int royal = 0;
            int roli = 0;
            int trofon = 0;
            int sino = 0;
            int guestLectors = 0;

            for (int i = 0; i < lessons; i++)
            {
                string lector = Console.ReadLine();

                if (lector == "Jelev")
                {
                    jelev++;
                }
                else if (lector == "RoYaL")
                {
                    royal++;
                }
                else if (lector == "Roli")
                {
                    roli++;
                }
                else if (lector == "Trofon")
                {
                    trofon++;
                }
                else if (lector == "Sino")
                {
                    sino++;
                }
                else
                {
                    guestLectors++;
                }
            }

            Console.WriteLine("Jelev salary: {0:f2} lv", jelev * paymentPerLesson);
            Console.WriteLine("RoYaL salary: {0:f2} lv", royal * paymentPerLesson);
            Console.WriteLine("Roli salary: {0:f2} lv", roli * paymentPerLesson);
            Console.WriteLine("Trofon salary: {0:f2} lv", trofon * paymentPerLesson);
            Console.WriteLine("Sino salary: {0:f2} lv", sino * paymentPerLesson);
            Console.WriteLine("Others salary: {0:f2} lv", guestLectors * paymentPerLesson);


        }
    }
}
