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

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieViewModel>> Get(int id)
        {
            var checkMovieExistence = movieDbSet.Include(e => e.Genres).FirstOrDefault(e => e.Id == id);
            if (checkMovieExistence == null)
                return NotFound();

            return await movieService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<MovieViewModel>> Post(MovieViewModel model)
        {
            var checkMovieExistence = movieDbSet.Include(e => e.Genres).Where(e => e.Id == model.Id).ToList();
            if (checkMovieExistence.Count() != 0)
                return BadRequest();

            await movieService.Create(model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieViewModel>> Put([FromRoute] int id, MovieViewModel model)
        {
            var checkMovieExistence = movieDbSet.Include(e => e.Genres).Where(e => e.Id == id);
            if (checkMovieExistence.Count() == 0)
                return NotFound();

            await movieService.Update(id, model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<MovieViewModel>> Delete(int[] ids)
        {
            var checkMovieExistence = await movieService.GetByIds(ids);
            if (checkMovieExistence == null)
                return NotFound();

            await movieService.Delete(ids);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
