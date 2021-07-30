﻿using System.Collections.Generic;

namespace WriteIT.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }
        public List<Series> Series { get; set; }
    }
}
