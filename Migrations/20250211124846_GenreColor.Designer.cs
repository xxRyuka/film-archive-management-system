﻿// <auto-generated />
using System;
using EFC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250211124846_GenreColor")]
    partial class GenreColor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("EFC.Data.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("ActorId");

                    b.ToTable("actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            FirstName = "Leonardo",
                            LastName = "DiCaprio"
                        },
                        new
                        {
                            ActorId = 2,
                            FirstName = "Brad",
                            LastName = "Pitt"
                        },
                        new
                        {
                            ActorId = 3,
                            FirstName = "Samet",
                            LastName = "Yarrakoğlu"
                        },
                        new
                        {
                            ActorId = 4,
                            FirstName = "Yusuf",
                            LastName = "Uzun"
                        },
                        new
                        {
                            ActorId = 5,
                            FirstName = "Murat",
                            LastName = "Karayilan"
                        });
                });

            modelBuilder.Entity("EFC.Data.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("DirectorId");

                    b.ToTable("directors");

                    b.HasData(
                        new
                        {
                            DirectorId = 1,
                            FirstName = "Christopher",
                            LastName = "Nolan"
                        },
                        new
                        {
                            DirectorId = 2,
                            FirstName = "Sena",
                            LastName = "Kuş"
                        },
                        new
                        {
                            DirectorId = 3,
                            FirstName = "Hamza",
                            LastName = "Demir"
                        },
                        new
                        {
                            DirectorId = 4,
                            FirstName = "Furkan",
                            LastName = "Kuş"
                        },
                        new
                        {
                            DirectorId = 5,
                            FirstName = "Saga",
                            LastName = "Saian"
                        });
                });

            modelBuilder.Entity("EFC.Data.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Color = "#fcad03",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Color = "#fcad03",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 3,
                            Color = "#fcad03",
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            GenreId = 4,
                            Color = "#fcad03",
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("EFC.Data.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Description = "Sci-Fi Thriller",
                            DirectorId = 1,
                            MovieTitle = "Inception",
                            ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MovieId = 2,
                            Description = "Psychological Drama",
                            DirectorId = 2,
                            MovieTitle = "Fight Club",
                            ReleaseDate = new DateTime(1999, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFC.Data.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActors");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            ActorId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            ActorId = 2
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 2
                        },
                        new
                        {
                            MovieId = 1,
                            ActorId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            ActorId = 4
                        });
                });

            modelBuilder.Entity("EFC.Data.MovieGenre", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenres");

                    b.HasData(
                        new
                        {
                            GenreId = 3,
                            MovieId = 1
                        },
                        new
                        {
                            GenreId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            GenreId = 4,
                            MovieId = 2
                        },
                        new
                        {
                            GenreId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            GenreId = 2,
                            MovieId = 1
                        });
                });

            modelBuilder.Entity("EFC.Data.Movie", b =>
                {
                    b.HasOne("EFC.Data.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("EFC.Data.MovieActor", b =>
                {
                    b.HasOne("EFC.Data.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFC.Data.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EFC.Data.MovieGenre", b =>
                {
                    b.HasOne("EFC.Data.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFC.Data.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("EFC.Data.Actor", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EFC.Data.Director", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EFC.Data.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("EFC.Data.Movie", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
