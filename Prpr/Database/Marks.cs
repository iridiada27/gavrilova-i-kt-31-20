
using Microsoft.EntityFrameworkCore;
using Prpr.Database.Configurations;
using Prpr.Models;

namespace Prpr.Database
{
    public class Marks: DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Otsenka> Otsenka { get; set; }
        DbSet<Subject> Subject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new OtsenkaConfiguration());
        }
        public Marks(DbContextOptions options): base(options) { }
    }
}
