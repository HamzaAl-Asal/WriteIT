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
                e.HasKey(d => d.Id);
                e.Property(d => d.Name).HasMaxLength(500).IsRequired();
                e.Property(d => d.Date);
            });
        }
    }
}
