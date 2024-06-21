namespace FileManager.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created {  get; set; }
        public DateTime? Updated { get; set; }
    }
}