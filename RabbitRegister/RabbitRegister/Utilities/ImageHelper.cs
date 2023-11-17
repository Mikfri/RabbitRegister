using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RabbitRegister.Utilities
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Rabbits");

            if (imageFile == null || imageFile.Length == 0)
            {
                return null;
            }

            string uniqueFileName = $"{Guid.NewGuid()}_{imageFile.FileName}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            string relativePath = Path.Combine("Images", "Rabbits", uniqueFileName);
            // Fjern det første skråstreg, hvis det er til stede
            if (relativePath.StartsWith("/"))
            {
                relativePath = relativePath.Substring(1);
            }

            return relativePath;
        }

        public static void DeleteImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        // Tilføj denne midlertidige metode til din ImageHelper-klasse
        public static void TestDeleteImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                string normalizedPath = Path.GetFullPath(imagePath);
                File.Delete(normalizedPath);
            }
        }
       
    }
}
