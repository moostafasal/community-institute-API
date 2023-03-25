using YourNamespace.Helpers;

namespace community_institute_API.Serves
{
    public class FileService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly FileHelper _fileHelper;

        public FileService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _fileHelper = new FileHelper(httpContextAccessor, configuration);
        }

        public async Task<string> SaveFile(IFormFile file, string directoryPath = "wwwroot/images/uploads")
        {
            return await _fileHelper.SaveFile(file, directoryPath);
        }
        // get file path
        public string GetFileUrl(string relativePath)
        {

            return _fileHelper.GetFileUrl(relativePath);

        }
        //downlod file
        public async Task DownloadFile(string filePath, string fileName)
        {
             _fileHelper.DownloadFile(filePath, fileName);
        }

    }
}
