using System.ComponentModel.DataAnnotations;

namespace FilEmanager.web.Models
{
    public class Folder:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Guid ParentId { get; set; }

        //Navigations
        public virtual Folder ParentFolder { get; set; }
        public virtual ICollection<Folder> ChildrenFolders { get; set; }
        public virtual ICollection<Files> Files { get; set; }
    }
}