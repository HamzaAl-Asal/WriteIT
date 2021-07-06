using System;
using System.Collections.Generic;
using System.Text;

namespace WriteIT.Abstractions.Models
{
   public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
    }
}
