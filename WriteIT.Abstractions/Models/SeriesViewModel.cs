﻿using System.Collections.Generic;

namespace WriteIT.Abstractions.Models
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BestCharacter { get; set; }
        public double MyRate { get; set; }
        public int ReleaseYear { get; set; }
        public int Season { get; set; }
        public List<GenreViewModel> Genres { get; set; }
    }
}
