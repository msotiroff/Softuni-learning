namespace P04.CopyBinaryFile
{
    using System.IO;

    public class StartUp
    {
        private const string SourseFile = "../Resourses/copyMe.png";
        private const string DestinationFile = "Output/copyMe-Copy.png";

        public static void Main(string[] args)
        {
            using (var reader = new FileStream(SourseFile, FileMode.Open))
            {
                using (var writer = new FileStream(DestinationFile, FileMode.Create))
                {
                    var buffer = new byte[4096];
                    int readBytes;
                    while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, readBytes);
                    }
                }
            }
            
        }
    }
}
