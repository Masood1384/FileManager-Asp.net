
namespace FileManager.Web
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileMapp).Assembly);
        }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Files> Files { get; set; }
    }
}
