namespace Standardly.Core.Services.Foundations.FileServices
{
    public interface IFileService
    {
        bool CheckIfFileExists(string path);
        void WriteToFile(string path, string content);
    }
}
