using Azure.Storage.Blobs;
using HW_Web__1_MVC_.Helpers;

namespace HW_Web__1_MVC_.Model
{
    public class AzureFileService : IFileServices
    {
        private readonly string connectPath;
        private const string containerName = "images";
        public AzureFileService(IConfiguration configuration)
        {
            connectPath = configuration.GetConnectionString("ConnectAzureStorage");
        }
        public Task DeleteAutoImage(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveAutoImage(IFormFile file)
        {
            var client = new BlobContainerClient(connectPath, containerName);

            await client.CreateIfNotExistsAsync();
            await client.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            // custom file name
            string name = Guid.NewGuid().ToString();    // random name
            string extension = Path.GetExtension(file.FileName); // get original extension
            string fileName = name + extension;         // full name: name.ext

            BlobClient blob = client.GetBlobClient(fileName);
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();
        }
    }
}
