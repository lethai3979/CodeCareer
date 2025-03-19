using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Application.Abstraction
{
    public interface ICloudService
    {
        public Task<string> UploadImageAsync(IFormFile image);
    }
}
