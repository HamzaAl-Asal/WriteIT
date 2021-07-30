using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WriteIT.Data.Models;

namespace WriteIT.Data
{
    public class WriteITContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=HAMZAPC\GREENLOCALDB;Database=WriteIT_DB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(e =>
            {
                e.HasMany(x => x.Genres).WithMany(x => x.Movies).UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    j => j
                        .HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_MovieGenre_Genres_GenreId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Movie>()
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieGenre_Movies_MovieId")
                        .OnDelete(DeleteBehavior.Cascade));

                e.Property(d => d.Name).HasMaxLength(500).IsRequired();
                e.Property(d => d.BestCharacter).HasMaxLength(200);
                e.Property(d => d.MyRate).HasDefaultValue(0.0);
                e.Property(d => d.ReleaseYear).IsRequired();
            });

            modelBuilder.Entity<Series>(e =>
            {
                e.HasMany(x => x.Genres).WithMany(x => x.Series).UsingEntity<Dictionary<string, object>>(
                      "SeriesGenre",
                      j => j
                          .HasOne<Genre>()
                          .WithMany()
                          .HasForeignKey("GenreId")
                          .HasConstraintName("FK_SeriesGenre_Genres_GenreId")
                          .OnDelete(DeleteBehavior.Cascade),
                      j => j
                          .HasOne<Series>()
                          .WithMany()
                          .HasForeignKey("SeriesId")
                          .HasConstraintName("FK_SeriesGenre_Series_SeriesId")
                          .OnDelete(DeleteBehavior.Cascade));

                e.Property(d => d.Name).HasMaxLength(500).IsRequired();
                e.Property(d => d.BestCharacter).HasMaxLength(200);
                e.Property(d => d.MyRate).HasDefaultValue(0.0);
                e.Property(d => d.ReleaseYear).IsRequired();
                e.Property(d => d.Season).IsRequired().HasDefaultValue(0);
            });
            modelBuilder.Entity<Genre>(e =>
            {
                e.HasIndex(d => d.Name).IsUnique();
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.HasData(
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "Animation" },
                    new Genre { Id = 3, Name = "Comedy" },
                    new Genre { Id = 4, Name = "Crime" },
                    new Genre { Id = 5, Name = "Drama" },
                    new Genre { Id = 6, Name = "Experimental" },
                    new Genre { Id = 7, Name = "Fantasy" },
                    new Genre { Id = 8, Name = "Historical" },
                    new Genre { Id = 9, Name = "Horror" },
                    new Genre { Id = 10, Name = "Romance" },
                    new Genre { Id = 11, Name = "Sci-Fi" },
                    new Genre { Id = 12, Name = "Thriller" },
                    new Genre { Id = 13, Name = "Western" },
                    new Genre { Id = 14, Name = "Musical" },
                    new Genre { Id = 15, Name = "War" },
                    new Genre { Id = 16, Name = "Biopics" },
                    new Genre { Id = 17, Name = "Superhero" },
                    new Genre { Id = 18, Name = "Documentary" },
                    new Genre { Id = 19, Name = "Sport" },
                    new Genre { Id = 20, Name = "Family" });
            });
        }
    }
}
