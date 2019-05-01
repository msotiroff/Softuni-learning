namespace P02.SliceFile
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class StartUp
    {
        private const string FileName = "../../../IO/HydroElectricWhirlpool.mp4";
        private const string SlicedFileDirectory = @"../../../IO/Pieces";

        public static void Main()
        {
            Console.Write("Enter, how many parts do you want to slice the video: ");

            var parts = int.Parse(Console.ReadLine());
            
            SliceAsync(parts);

            Console.WriteLine("Anything else?");

            string input;
            while ((input = Console.ReadLine()) != "Exit")
            {
                // Read some text from console! It should be responsive!
            }
        }

        private static void SliceAsync(int parts)
        {
            Task
                .Run(() =>
                {
                    SliceFile(parts);
                });
        }

        private static void SliceFile(int parts)
        {
            if (!Directory.Exists(SlicedFileDirectory))
            {
                Directory.CreateDirectory(SlicedFileDirectory);
            }

            using (var source = new FileStream(FileName, FileMode.Open))
            {
                var fileInfo = new FileInfo(FileName);

                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currPart = 1; currPart <= parts; currPart++)
                {
                    var currPartPath = $"{SlicedFileDirectory}/Part-{currPart}{fileInfo.Extension}";

                    using (var destination = new FileStream(currPartPath, FileMode.Create))
                    {
                        var buffer = new byte[1024];

                        while (currentByte <= partLength * currPart)
                        {
                            var readBytesCount = source.Read(buffer, 0, buffer.Length);

                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }

                //Thread.Sleep(10000);

                Console.WriteLine("Slicing completed!");
            }
        }
    }
}
