using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Data;
using WriteIT.Data.Models;

namespace WriteIT.Services
{
    public class SeriesService
    {
        private readonly DbSet<Series> seriesDbSet;
        private readonly IMapper mapper;
        public SeriesService(WriteITContext context, IMapper mapper)
        {
            this.seriesDbSet = context.Set<Series>();
            this.mapper = mapper;
        }
        public async Task<List<SeriesViewModel>> Get()
        {
            var series = await seriesDbSet.ToListAsync();
            return mapper.Map<List<SeriesViewModel>>(series);
        }
        public Task<SeriesViewModel> Get(int id)
        {
            var series = seriesDbSet.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(mapper.Map<SeriesViewModel>(series));
        }
        public async Task<List<SeriesViewModel>> GetByIds(int[] ids)
        {
            var series = await seriesDbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
            return mapper.Map<List<SeriesViewModel>>(series);
        }
        public Task Create(SeriesViewModel model)
        {
            seriesDbSet.Add(mapper.Map<Series>(model));

            return Task.CompletedTask;
        }
        public Task Update([FromRoute] int id, SeriesViewModel model)
        {
            var series = seriesDbSet.FirstOrDefault(e => e.Id == id);

            series.Name = model.Name;
            series.MyRate = model.MyRate;
            series.Genre = model.Genre;
            series.BestCharacter = model.BestCharacter;
            series.ReleaseYear = model.ReleaseYear;
            series.Season = model.Season;

            return Task.CompletedTask;
        }
        public Task Delete(int[] ids)
        {
            var series = seriesDbSet.Where(e => ids.Contains(e.Id)).ToList();
            seriesDbSet.RemoveRange(series);

            return Task.CompletedTask;
        }
    }
}
