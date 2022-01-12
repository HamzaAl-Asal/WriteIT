using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Interfaces;

namespace WriteIT.Controllers
{
    [Route("api/genre/lookup")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenre genre;

        public GenreController(IGenre genre)
        {
            this.genre = genre;
        }

        public async Task<List<GenreViewModel>> Get()
        {
            return await genre.Get();
        }
    }
}
