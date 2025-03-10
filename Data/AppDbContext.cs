using Microsoft.EntityFrameworkCore;

namespace EFC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Director> directors { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Genre> genres { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        // public DbSet<rew> MyProperty { get; set; } -> İlerde yorumlar eklenecek


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Movie - Director  one to many
            modelBuilder.Entity<Movie>()
                        .HasOne(m => m.Director)
                        .WithMany(d => d.Movies)
                        .HasForeignKey(fk => fk.DirectorId)
                        .OnDelete(DeleteBehavior.Cascade);


            // Movie - Actor many to many

            #region Movie - Actor Many to Many
            //COMPOSITE PRIMARY KEY

            modelBuilder.Entity<MovieActor>()
                        .HasKey(ma => new { ma.MovieId, ma.ActorId });  // iki tane primary key koyduk bu sekilde


            modelBuilder.Entity<MovieActor>()
                        .HasOne(a => a.Actor)
                        .WithMany(m => m.Movies)
                        .HasForeignKey(a => a.ActorId);

            modelBuilder.Entity<MovieActor>()
                        .HasOne(m => m.Movie)
                        .WithMany(a => a.Actors)
                        .HasForeignKey(m => m.MovieId);
            #endregion
        
            #region Movie - Genre Many to Many
            
            // composite key -> Tabloda 2 primary key olcak

            modelBuilder.Entity<MovieGenre>()
                        .HasKey(mg => new {mg.GenreId , mg.MovieId}); // -> 2 adet primary key tanımladık

            modelBuilder.Entity<MovieGenre>()
                        .HasOne(m => m.Movie)
                        .WithMany(g => g.Genres)
                        .HasForeignKey(m=> m.MovieId);

            modelBuilder.Entity<MovieGenre>()
                        .HasOne(g=> g.Genre)
                        .WithMany(m=>m.Movies)
                        .HasForeignKey(g=>g.GenreId);

            #endregion
            
        


            #region seed data

        // Seed Data
       modelBuilder.Entity<Actor>().HasData(
           new Actor { ActorId = 1, FirstName = "Leonardo", LastName = "DiCaprio" },
           new Actor { ActorId = 2, FirstName = "Brad", LastName = "Pitt" },
           new Actor { ActorId = 4, FirstName = "Yusuf", LastName = "Uzun" },
           new Actor { ActorId = 5, FirstName = "Murat", LastName = "Karayilan" }

       );

       modelBuilder.Entity<Director>().HasData(
           new Director { DirectorId = 1, FirstName = "Christopher", LastName = "Nolan" },
           new Director { DirectorId = 2, FirstName = "Sena", LastName = "Kuş" },
           new Director { DirectorId = 3, FirstName = "Hamza", LastName = "Demir" },
           new Director { DirectorId = 4, FirstName = "Furkan", LastName = "Kuş" },
           new Director { DirectorId = 5, FirstName = "Saga", LastName = "Saian" }

       );

       modelBuilder.Entity<Genre>().HasData(
           new Genre { GenreId = 1, Name = "Action" },
           new Genre { GenreId = 2, Name = "Drama" },
           new Genre { GenreId = 3, Name = "Sci-Fi" },
           new Genre { GenreId = 4, Name = "Romance" }
       );

       modelBuilder.Entity<Movie>().HasData(
           new Movie { MovieId = 1, MovieTitle = "Inception", Description = "Sci-Fi Thriller", ReleaseDate = new DateTime(2010, 7, 16), DirectorId = 1 },
           new Movie { MovieId = 2, MovieTitle = "Fight Club", Description = "Psychological Drama", ReleaseDate = new DateTime(1999, 10, 15), DirectorId = 2 }
       );

       modelBuilder.Entity<MovieActor>().HasData(
        new MovieActor {ActorId=1, MovieId=1},
        new MovieActor {ActorId=2, MovieId=2},
        new MovieActor {ActorId=2, MovieId=1},
        new MovieActor {ActorId=3, MovieId=1},
        new MovieActor {ActorId=4, MovieId=2}
       );


       modelBuilder.Entity<MovieGenre>().HasData(
        new MovieGenre {MovieId = 1, GenreId=3},
        new MovieGenre {MovieId = 1, GenreId=1},
        new MovieGenre {MovieId = 2, GenreId=4},
        new MovieGenre {MovieId = 2, GenreId=2},
        new MovieGenre {MovieId = 1, GenreId=2}
       );
            #endregion
        }

    }
}
