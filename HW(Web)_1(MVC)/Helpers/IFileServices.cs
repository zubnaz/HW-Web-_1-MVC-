namespace HW_Web__1_MVC_.Helpers
{
    public interface IFileServices
    {
        Task<string> SaveAutoImage(IFormFile file);
        Task DeleteAutoImage(string path);
    }
}
