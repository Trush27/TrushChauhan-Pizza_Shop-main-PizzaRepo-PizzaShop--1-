
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Service.Interfaces;

namespace Services.Implementations
{

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveProfileImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "profiles");
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return $"/images/profiles/{uniqueFileName}";
        }
    }
}