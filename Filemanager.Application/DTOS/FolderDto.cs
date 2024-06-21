
namespace Filemanager.Application.DTOS
{
    public class FolderDto:BaseDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        //Navigations
        public virtual FolderDto ParentFolder { get; set; }
        public virtual ICollection<FolderDto> ChildrenFolders { get; set; }
        public virtual ICollection<FileDto> Files { get; set; }
    }
    public class AddFolderDto
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
    public class UpdateFolderDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
