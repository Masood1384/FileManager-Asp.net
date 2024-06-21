using Filemanager.Application.DTOS;

namespace FileManager.Web.Models
{
    public class MainModel
    {
        public List<FolderDto> Folder { get; set; }
        public List<FileDto> File { get; set; }
        public Guid FolderId { get; set; }
    }
}
