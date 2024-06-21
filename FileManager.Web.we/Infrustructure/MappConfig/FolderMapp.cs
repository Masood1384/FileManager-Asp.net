
namespace FilEmanager.web.Infrustructure.MappConfig
{
    public class FolderMapp : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {
            builder.HasMany(p => p.ChildrenFolders).WithOne(p => p.ParentFolder).HasForeignKey(p => p.ParentId);
        }

    }
}