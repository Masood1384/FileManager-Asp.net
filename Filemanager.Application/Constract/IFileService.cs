
namespace Filemanager.Application.Constract
{
    public interface IFileService
    {
        Task<List<FileDto>> GetAllFiles();
        Task<List<FileDto>> GetAllFileByFolder(Guid folderId);
        Task<FileDto> GetFileById(Guid id);
        Task<FileDto> AddFiles(AddFileDto file);
        Task<bool> DeleteFiles(Guid fileId);
        Task<FileDto> RenameFile(string Filename , Guid fileId);
        Task<FileDto> MoveFile(Guid FileId, Guid FolderId);
    }
}
