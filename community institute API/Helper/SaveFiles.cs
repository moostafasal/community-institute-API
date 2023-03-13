using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace YourNamespace.Helpers
{
    public   class FileHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public FileHelper(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            
        }


        public  async Task<string> SaveFile(IFormFile file, string directoryPath = "wwwroot/images/uploads")
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("File is empty");
            }

       


        // Generate a unique file name based on a GUID and the original file extension
        var extension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + extension;

            // Combine the directory path and file name to get the full file path
            var filePath = Path.Combine(directoryPath, fileName);
            
            // Save the file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the URL for the saved file
            var relativePath = Path.Combine(directoryPath.Replace("wwwroot", ""), fileName);
            return relativePath;
        }
        //get file path
        public  string GetFileUrl(string relativePath)
        {
            var baseUrl = GetBaseUrl();
            var url = new Uri(new Uri(baseUrl), relativePath).ToString();
            return url;
            
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        private  string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var scheme = request.Scheme;
            var host = request.Host.Value;
            var pathBase = request.PathBase.Value;

            return $"{scheme}://{host}{pathBase}";
        }

    }

}



