namespace P06.ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;

    public class StartUp
    {
        private const string SourseFilePath = "../Resourses/sliceMe.mp4";
        private const string DestinationDirectoryPath = "Output/";
        private static List<string> piecesPaths;
        private static readonly string extension = SourseFilePath.Split('.').Last();

        public static void Main(string[] args)
        {
            Console.Write("How many pieces: ");

            var pieces = int.Parse(Console.ReadLine());

            piecesPaths = new List<string>();

            Slice(SourseFilePath, pieces);

            Assemble(piecesPaths);
        }
        
        private static void Slice(string soursePath, int pieces)
        {
            if (!Directory.Exists(DestinationDirectoryPath))
            {
                Directory.CreateDirectory(DestinationDirectoryPath);
            }

            using (var reader = new FileStream(soursePath, FileMode.Open, FileAccess.Read))
            {
                var sizePerPiece = (uint)(Math.Ceiling((double)reader.Length / pieces));

                for (int piece = 1; piece <= pieces; piece++)
                {
                    using (var writer = new FileStream(DestinationDirectoryPath + $"Part-{piece}.{extension}.gz", FileMode.Create))
                    {
                        using (var compresser = new GZipStream(writer, CompressionMode.Compress, false))
                        {
                            byte[] buffer = new byte[sizePerPiece];
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            compresser.Write(buffer, 0, readBytes);
                            piecesPaths.Add(DestinationDirectoryPath + $"Part-{piece}.{extension}.gz");
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> piecesPaths)
        {
            for (int piece = 0; piece < piecesPaths.Count; piece++)
            {
                using (FileStream reader = new FileStream(piecesPaths[piece], FileMode.Open))
                {
                    using (FileStream writer = new FileStream(DestinationDirectoryPath + $"assembled.{extension}", FileMode.Append))
                    {
                        byte[] buffer = new byte[reader.Length];
                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
