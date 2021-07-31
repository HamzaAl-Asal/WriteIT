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
    [Route("api/series")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesService seriesService;
        private readonly DbSet<Series> seriesDbSet;
        private readonly WriteITContext context;

        public SeriesController(SeriesService seriesService, WriteITContext context)
        {
            this.seriesService = seriesService;
            this.seriesDbSet = context.Set<Series>();
            this.context = context;
        }

        public async Task<List<SeriesViewModel>> Get()
        {
            return await seriesService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesViewModel>> Get(int id)
        {
            var checkSeriesExistence = seriesDbSet.Include(e => e.Genres).FirstOrDefault(e => e.Id == id);
            if (checkSeriesExistence == null)
                return NotFound();

            return await seriesService.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<SeriesViewModel>> Post(SeriesViewModel model)
        {
            var checkSeriesExistence = seriesDbSet.Include(e => e.Genres).Where(e => e.Id == model.Id).ToList();
            if (checkSeriesExistence.Count() != 0)
                return BadRequest();

            await seriesService.Create(model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SeriesViewModel>> Put([FromRoute] int id, SeriesViewModel model)
        {
            var checkSeriesExistence = seriesDbSet.Include(e => e.Genres).Where(e => e.Id == id);
            if (checkSeriesExistence.Count() == 0)
                return NotFound();

            await seriesService.Update(id, model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int[] ids)
        {
            var checkSeriesExistence = await seriesService.GetByIds(ids);
            if (checkSeriesExistence == null)
                return NotFound();

            await seriesService.Delete(ids);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
