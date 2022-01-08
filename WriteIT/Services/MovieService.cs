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
    public class MovieService : IMovie
    {
        private readonly DbSet<Movie> movieDbSet;
        private readonly IMapper mapper;
        private readonly WriteITContext dbContext;

        public MovieService(IMapper mapper, WriteITContext dbContext)
        {
            this.movieDbSet = dbContext.Set<Movie>();
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
        public async Task<List<MovieViewModel>> Get()
        {
            var movies = await movieDbSet.Include(e => e.Genres).ToListAsync();
            return mapper.Map<List<MovieViewModel>>(movies);
        }
        public async Task<MovieViewModel> Get(int id)
        {
            var movie = await movieDbSet.Include(e => e.Genres).FirstOrDefaultAsync(e => e.Id == id);

            if (movie == null)
                throw new ArgumentNullException($"This Movie is Not Found in our database !");

            return mapper.Map<MovieViewModel>(movie);
        }
        public async Task<List<MovieViewModel>> GetByIds(int[] ids)
        {
            var movies = await movieDbSet.Include(e => e.Genres).Where(x => ids.Contains(x.Id)).ToListAsync();
            return mapper.Map<List<MovieViewModel>>(movies);
        }
        public async Task Create(MovieViewModel model)
        {
            if (model.Id != 0)
                throw new ArgumentException("Do not enter Id while create proccess !!");

            await movieDbSet.AddAsync(mapper.Map<Movie>(model));
            await dbContext.SaveChangesAsync();
        }
        public async Task Update([FromRoute] int id, MovieViewModel model)
        {
            var movie = await movieDbSet.Include(e => e.Genres).FirstOrDefaultAsync(e => e.Id == id);

            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException("Movie Name Cannot be null !");

            movie.Name = model.Name;
            movie.MyRate = model.MyRate;
            movie.BestCharacter = model.BestCharacter;
            movie.ReleaseYear = model.ReleaseYear;

            await dbContext.SaveChangesAsync();
        }
        public async Task Delete(int[] ids)
        {
            var movies = await movieDbSet.Include(e => e.Genres).Where(e => ids.Contains(e.Id)).ToListAsync();
            movieDbSet.RemoveRange(movies);

            await dbContext.SaveChangesAsync();
        }
    }
}
