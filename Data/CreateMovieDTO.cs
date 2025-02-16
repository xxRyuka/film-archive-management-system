namespace EFC.Data
{
    public class CreateMovieDTO
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? ReleaseDate { get; set; }
        public string? MovieImg { get; set; } = "movie.jpg";
        public int DirectorId { get; set; } // Yönetmeni seçmek için

        public List<int> ActorIds { get; set; } = new List<int>(); // Seçilen aktör ID'leri
        public List<int> GenreIds { get; set; } = new List<int>(); // Seçilen tür ID'leri

    }
}