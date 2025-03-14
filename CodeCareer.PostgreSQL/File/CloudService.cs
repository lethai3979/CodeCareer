using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CodeCareer.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.File
{
    public class CloudService : ICloudService
    {
        private readonly Cloudinary _cloudinary;
        private readonly string _defaultImage = "https://coffective.com/wp-content/uploads/2018/06/default-featured-image.png.jpg";

        public CloudService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return _defaultImage;
            }

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                UseFilename = true,
                Folder = "CodeCareer",
                Overwrite = true
            };
            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            
            return uploadResult.SecureUrl?.AbsoluteUri ?? _defaultImage;
        }
    }
}
