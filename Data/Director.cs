using System.ComponentModel.DataAnnotations;

namespace EFC.Data
{
    public class Director
    {
        public int DirectorId { get; set; }

        public string? Bio { get; set; } = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Itaque rem voluptates atque. Nostrum ipsa iusto ";


        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ActorImg { get; set; } = "default.jpg";

        public string FullName => this.FirstName + " " + this.LastName;

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}