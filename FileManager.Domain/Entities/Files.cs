
namespace FileManager.Domain.Entities
{
    public class Files : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string extension { get; set; }
        public byte[] File { get; set; }
        public long Size { get; set; }
        public Guid? FolderId { get; set; }

        //Navigations
        public virtual Folder? Folders { get; set; }
    }
}