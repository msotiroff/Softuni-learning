namespace SoftUniClone.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Threading.Tasks;

    public static class FormFileExtensions
    {
        public static async Task<byte[]> ToByteArray(this IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}