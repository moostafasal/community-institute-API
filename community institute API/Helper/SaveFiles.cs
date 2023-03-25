using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
        public  string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var scheme = request.Scheme;
            var host = request.Host.Value;
            var pathBase = request.PathBase.Value;

            return $"{scheme}://{host}{pathBase}";
        }

        public FileStreamResult DownloadFile(string relativePath, string fileName)
        {
            // Combine the directory path and file name to get the full file path using GetBaseUrl()
            var filePath = Path.Combine(GetBaseUrl(), relativePath);

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                throw new Exception("File not found");
            }

            // Set the content type based on the file extension
            var contentType = "application/octet-stream";
            var extension = Path.GetExtension(filePath);
            if (!string.IsNullOrEmpty(extension))
            {
                var provider = new FileExtensionContentTypeProvider();
                provider.TryGetContentType(extension, out contentType);
            }

            // Set the file name for the download
            var downloadFileName = fileName ?? Path.GetFileName(filePath);

            // Return the file as a stream for download
            var stream = new FileStream(filePath, FileMode.Open);
            return new FileStreamResult(stream, contentType)
            {
                FileDownloadName = downloadFileName
            };
        }




    }

}



