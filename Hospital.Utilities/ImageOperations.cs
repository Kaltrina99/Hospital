using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hospital.Utilities
{
    public class ImageOperations
    {
        private readonly IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }

        public bool IsImageValid(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false; // No file or empty file
            }

            // Check if the file is an image based on its content type
            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!Array.Exists(allowedContentTypes, contentType => contentType == file.ContentType))
            {
                return false; // Invalid content type
            }

            // Check if the file size is within an acceptable limit (e.g., 5MB)
            var maxFileSizeInBytes = 5 * 1024 * 1024; // 5MB
            if (file.Length > maxFileSizeInBytes)
            {
                return false; // File size exceeds the limit
            }

            return true; // File is valid
        }

        public async Task<string> SaveImageAsync(IFormFile file, string fileName)
        {
            try
            {
                if (IsImageValid(file))
                {
                    var uploadDirectory = Path.Combine(_env.WebRootPath, "Images");
                    var filePath = Path.Combine(uploadDirectory, fileName);

                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(uploadDirectory);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    return Path.Combine("Images", fileName); // Return the relative path to the saved image
                }

                return null; // Invalid image, not saved
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., IO errors) here
                return null;
            }
        }
    }
}
