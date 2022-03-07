using Microsoft.EntityFrameworkCore;

namespace The_Archivist.Models
{
    public class ArchivistDBContext:DbContext
    {
        public ArchivistDBContext(DbContextOptions<ArchivistDBContext> options) : base(options)
        {
           
        }

        public DbSet<Orgnization> orgnizations { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Archive> archives { get; set; }
        public DbSet<OrgType> orgTypes { get; set; }
        public DbSet<ArchiveType> archiveTypes { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Employee> employees { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source = FAILURE;Initial Catalog =The-Archivist;Integrated Security=True;");
        }
    }
}
