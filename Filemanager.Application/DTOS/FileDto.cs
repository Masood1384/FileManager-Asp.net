
namespace Filemanager.Application.DTOS
{
    public class FileDto:BaseDto
    {
        public string Name { get; set; }
        public string extension { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public Guid? FolderId { get; set; }

        //Navigations
        public virtual FolderDto? Folders { get; set; }
    }
    public class AddFileDto
    {
        public string Name { get; set; }
        public string extension { get; set; }
        public IFormFile FileUpload { get; set; }
        public Guid? FolderId { get; set; }

    }
}
