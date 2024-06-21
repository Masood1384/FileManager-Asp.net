namespace Filemanager.Application.DTOS
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
