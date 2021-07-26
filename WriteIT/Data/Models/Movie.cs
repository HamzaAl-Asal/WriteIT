namespace WriteIT.Data.Models
{
    public class Movie 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BestCharacter { get; set; }
        public string Genre { get; set; }
        public double MyRate { get; set; }
        public int ReleaseYear { get; set; }
    }
}