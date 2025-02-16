using System.ComponentModel.DataAnnotations;

namespace EFC.Data
{
    public class Actor
    {


        public int ActorId { get; set; }

  
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? ActorImg { get; set; } = "default.jpg";

        public string FullName => this.FirstName+" "+this.LastName;

        //İlişkili Değerler 

        //Movies 
        public ICollection<MovieActor> Movies { get; set; } = new List<MovieActor>(); 
    }
}