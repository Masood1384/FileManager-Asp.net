
namespace Filemanager.Application.Constract
{
    public interface IFolderService
    {
        Task<List<FolderDto>> GetAllFolder();
        Task<List<FolderDto>> GetFolderByFolder(Guid folderId);
        Task<FolderDto> AddFolder(AddFolderDto folderDto);
        Task<FolderDto> UpdateFolder(UpdateFolderDto folderDto);
        Task<bool> DeleteFolderAndFile(List<Guid> SelectedFolder);
        Task<FolderDto> MoveFolderAndFile(Guid Id, Guid ToFolderId);
    }
}
