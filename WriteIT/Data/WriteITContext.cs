using Microsoft.EntityFrameworkCore;
using WriteIT.Data.Models;

namespace WriteIT.Data
{
    public class WriteITContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=HAMZAPC\GREENLOCALDB;Database=WriteIT_DB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(e =>
            {
                e.Property(d => d.Name).HasMaxLength(500).IsRequired();
                e.Property(d => d.Genre).HasMaxLength(100);
                e.Property(d => d.BestCharacter).HasMaxLength(200);
                e.Property(d => d.MyRate).HasDefaultValue(0.0);
                e.Property(d => d.ReleaseYear).IsRequired();
            }
            
            );
        }
    }
}
