using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.ClassBoxDataValidation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            try
            {
                var currentBox = new Box(double.Parse(Console.ReadLine()),
                                        double.Parse(Console.ReadLine()),
                                        double.Parse(Console.ReadLine())
                                    );

                Console.WriteLine($"Surface Area - {currentBox.GetSurface():f2}");
                Console.WriteLine($"Lateral Surface Area - {currentBox.GetLateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {currentBox.GetVolume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }
    }
}
