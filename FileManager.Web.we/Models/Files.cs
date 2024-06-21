using System.ComponentModel.DataAnnotations;

namespace FilEmanager.web.Models
{
    public class Files:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string extension { get; set; }
        public Guid FolderId { get; set; }

        //Navigations
        public virtual Folder Folders { get; set; }
    }
}