using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Interfaces;

namespace WriteIT.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovie movie;

        public MovieController(IMovie movie)
        {
            this.movie = movie;
        }

        public async Task<List<MovieViewModel>> Get()
        {
            return await movie.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieViewModel>> Get(int id)
        {
            return await movie.Get(id);
        }

        [HttpPost]
        public async Task Post(MovieViewModel model)
        {
            await movie.Create(model);
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] int id, MovieViewModel model)
        {
            await movie.Update(id, model);
        }

        [HttpDelete]
        public async Task Delete(int[] ids)
        {
            await movie.Delete(ids);
        }
    }
}
