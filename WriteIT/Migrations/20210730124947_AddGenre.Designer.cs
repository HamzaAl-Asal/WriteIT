﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WriteIT.Data;

namespace WriteIT.Migrations
{
    [DbContext(typeof(WriteITContext))]
    [Migration("20210730124947_AddGenre")]
    partial class AddGenre
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenre");
                });

            modelBuilder.Entity("SeriesGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("SeriesGenre");
                });

            modelBuilder.Entity("WriteIT.Data.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Animation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Crime"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Experimental"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Historical"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Western"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Musical"
                        },
                        new
                        {
                            Id = 15,
                            Name = "War"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Biopics"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Superhero"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Family"
                        });
                });

            modelBuilder.Entity("WriteIT.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BestCharacter")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("MyRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WriteIT.Data.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BestCharacter")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("MyRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<int>("Season")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MovieGenre", b =>
                {
                    b.HasOne("WriteIT.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_MovieGenre_Genres_GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WriteIT.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieGenre_Movies_MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeriesGenre", b =>
                {
                    b.HasOne("WriteIT.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_SeriesGenre_Genres_GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WriteIT.Data.Models.Series", null)
                        .WithMany()
                        .HasForeignKey("SeriesId")
                        .HasConstraintName("FK_SeriesGenre_Series_SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}