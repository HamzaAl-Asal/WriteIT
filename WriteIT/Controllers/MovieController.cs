using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Data;
using WriteIT.Data.Models;
using WriteIT.Services;

namespace WriteIT.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService movieService;
        private readonly DbSet<Movie> movieDbSet;
        private readonly WriteITContext context;

        public MovieController(MovieService movieService, WriteITContext context)
        {
            this.movieService = movieService;
            this.movieDbSet = context.Set<Movie>();
            this.context = context;
        }

        public async Task<List<MovieViewModel>> Get()
        {
            return await movieService.Get();
        }
        
        public async Task<List<MovieViewModel>> Get(int[] ids)
        {
            return await movieService.GetByIds(ids);
        }
        
        [HttpPost]
        public async Task<ActionResult<MovieViewModel>> Post(MovieViewModel model)
        {
            var checkMovie = movieDbSet.Where(e => e.Id == model.Id).ToList();
            if (checkMovie.Count() != 0)
                return BadRequest();

            await movieService.Create(model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieViewModel>> Put([FromRoute] int id, MovieViewModel model)
        {
            var checkMovie = movieDbSet.Where(e => e.Id == id);
            if (checkMovie.Count() == 0)
                return NotFound();

            await movieService.Update(id, model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<MovieViewModel>> Delete(int[] ids)
        {
            var getMovies = movieService.GetByIds(ids).Result;

            if (getMovies == null)
                return NotFound();

            await movieService.Delete(ids);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
