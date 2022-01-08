using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;

namespace WriteIT.Interfaces
{
    public interface IMovie
    {
        public Task<List<MovieViewModel>> Get();
        public Task<MovieViewModel> Get(int id);
        public Task<List<MovieViewModel>> GetByIds(int[] ids);
        public Task Create(MovieViewModel model);
        public Task Update([FromRoute] int id, MovieViewModel model);
        public Task Delete(int[] ids);
    }
}
