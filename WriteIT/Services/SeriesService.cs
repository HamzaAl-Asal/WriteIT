using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Data;
using WriteIT.Data.Models;
using WriteIT.Interfaces;

namespace WriteIT.Services
{
    public class SeriesService : ISeries
    {
        private readonly IMapper mapper;
        private readonly WriteITContext dbContext;

        public SeriesService(WriteITContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<SeriesViewModel>> Get()
        {
            var series = await dbContext.Series.Include(e => e.Genres).ToListAsync();

            return mapper.Map<List<SeriesViewModel>>(series);
        }

        public async Task<SeriesViewModel> Get(int id)
        {
            var series = await dbContext.Series.Include(e => e.Genres).FirstOrDefaultAsync(e => e.Id == id);

            if (series == null)
                throw new ArgumentNullException("This Series is Not Found in our database !");

            return mapper.Map<SeriesViewModel>(series);
        }

        public async Task<List<SeriesViewModel>> GetByIds(int[] ids)
        {
            var series = await dbContext.Series.Include(e => e.Genres).Where(x => ids.Contains(x.Id)).ToListAsync();

            if (series.Count == 0)
                throw new ArgumentNullException("No results found !");

            return mapper.Map<List<SeriesViewModel>>(series);
        }

        public async Task Create(SeriesViewModel model)
        {
            if (model.Id != 0 || string.IsNullOrEmpty(model.Name))
                throw new ArgumentException("Unable to save, try again later !");

            await dbContext.Series.AddAsync(mapper.Map<Series>(model));
            await dbContext.SaveChangesAsync();
        }

        public async Task Update([FromRoute] int id, SeriesViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException("Series Name Cannot be null Or Empty !");

            var series = await dbContext.Series.Include(e => e.Genres).FirstOrDefaultAsync(e => e.Id == id);

            series.Name = model.Name;
            series.MyRate = model.MyRate;
            series.BestCharacter = model.BestCharacter;
            series.ReleaseYear = model.ReleaseYear;
            series.Season = model.Season;

            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(int[] ids)
        {
            var series = await dbContext.Series.Include(e => e.Genres).Where(e => ids.Contains(e.Id)).ToListAsync();
            dbContext.Series.RemoveRange(series);

            await dbContext.SaveChangesAsync();
        }
    }
}
