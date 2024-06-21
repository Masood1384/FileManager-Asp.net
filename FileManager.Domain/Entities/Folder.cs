
namespace FileManager.Domain.Entities
{
    public class Folder : BaseEntity
    {
        
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        //Navigations
        public virtual Folder? ParentFolder { get; set; }
        public virtual ICollection<Folder>? ChildrenFolders { get; set; }
        public virtual ICollection<Files>? Files { get; set; }
    }
}