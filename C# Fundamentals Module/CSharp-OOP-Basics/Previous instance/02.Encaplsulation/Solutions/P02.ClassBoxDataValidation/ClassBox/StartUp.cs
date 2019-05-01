namespace ClassBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    class StartUp
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLiteralSurface():f2}");
                Console.WriteLine($"Volume - {box.GetVolume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
