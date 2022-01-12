using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;

namespace WriteIT.Interfaces
{
    public interface IGenre
    {
        public Task<List<GenreViewModel>> Get();
    }
}
