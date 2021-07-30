using System.Collections.Generic;
namespace WriteIT.Data.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BestCharacter { get; set; }
        public double MyRate { get; set; }
        public int ReleaseYear { get; set; }
        public int Season { get; set; }
        public List<Genre> Genres { get; set; }
    }
}