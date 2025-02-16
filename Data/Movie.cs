using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Data
{
    public class Movie
    {

        public int MovieId { get; set; }


        public string? MovieTitle { get; set; }


        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? MovieImg { get; set; } = "movie.jpg";


        //----- Simdi İliskili Değerler

        //Yonetmen
        public int DirectorId { get; set; } // foreign key
        public Director Director { get; set; } = null!; // Navigation Prop


        //Oyuncular

        public ICollection<MovieActor> Actors { get; set; } = new List<MovieActor>();


        //Kategoriler  
        public ICollection<MovieGenre> Genres { get; set; } = new List<MovieGenre>();


    }
}