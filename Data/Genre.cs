using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace EFC.Data
{
    public class Genre
    {

        public int GenreId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; } 

        public string? Color { get; set; } = "#fcad03";
         // renk kodu 

        //iliskisel kisimlar

        public ICollection<MovieGenre> Movies { get; set; } = new List<MovieGenre>();

    }
}