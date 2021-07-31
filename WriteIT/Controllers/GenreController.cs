using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Services;

namespace WriteIT.Controllers
{
    [Route("api/genre/lookup")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly GenreService genreService;

        public GenreController(GenreService genreService)
        {
            this.genreService = genreService;
        }

        public async Task<List<GenreViewModel>> Get()
        {
            return await genreService.Get();
        }
    }
}
