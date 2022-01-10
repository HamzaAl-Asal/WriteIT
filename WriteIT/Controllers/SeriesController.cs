using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Interfaces;

namespace WriteIT.Controllers
{
    [Route("api/series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeries series;

        public SeriesController(ISeries series)
        {
            this.series = series;
        }

        public async Task<List<SeriesViewModel>> Get()
        {
            return await series.Get();
        }

        [HttpGet("{id}")]
        public async Task<SeriesViewModel> Get(int id)
        {
            return await series.Get(id);
        }

        [HttpPost]
        public async Task Post(SeriesViewModel model)
        {
            await series.Create(model);
        }

        [HttpPut("{id}")]
        public async Task Put([FromRoute] int id, SeriesViewModel model)
        {
            await series.Update(id, model);
        }

        [HttpDelete]
        public async Task Delete(int[] ids)
        {
            await series.Delete(ids);
        }
    }
}
