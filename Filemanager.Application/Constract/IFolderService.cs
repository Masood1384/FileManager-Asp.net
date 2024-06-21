
namespace Filemanager.Application.Constract
{
    public interface IFolderService
    {
        Task<List<FolderDto>> GetAllFolder();
        Task<List<FolderDto>> GetFolderByFolder(Guid folderId);
        Task<FolderDto> AddFolder(AddFolderDto folderDto);
        Task<FolderDto> UpdateFolder(UpdateFolderDto folderDto);
        Task<bool> DeleteFolder(Guid folderId);
        Task<FolderDto> MoveFolder(Guid FolderId, Guid ToFolderId);
    }
}
