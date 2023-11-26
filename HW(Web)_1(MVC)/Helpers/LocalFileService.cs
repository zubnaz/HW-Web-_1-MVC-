namespace HW_Web__1_MVC_.Helpers
{
    public class LocalFileService: IFileServices
    {
        private const string imageFolder = "images";
        private readonly IWebHostEnvironment environment;

        public LocalFileService(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public Task DeleteAutoImage(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SaveAutoImage(IFormFile file)
        {

            
            string root = environment.WebRootPath;     
            string name = Guid.NewGuid().ToString();    
            string extension = Path.GetExtension(file.FileName); 
            string fullName = name + extension;         

            string imagePath = Path.Combine(imageFolder, fullName);
            string imageFullPath = Path.Combine(root, imagePath);

            
            using (FileStream fs = new FileStream(imageFullPath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            
            return imagePath;
        }
    }
}
