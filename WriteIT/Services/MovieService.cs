﻿using AutoMapper;
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
    public class MovieService
    {
        private readonly DbSet<Movie> movieDbSet;
        private readonly IMapper mapper;
        public MovieService(WriteITContext context, IMapper mapper)
        {
            this.movieDbSet = context.Set<Movie>();
            this.mapper = mapper;
        }
        public async Task<List<MovieViewModel>> Get()
        {
            var movies = await movieDbSet.ToListAsync();
            return mapper.Map<List<MovieViewModel>>(movies);
        } 
        public async Task<List<MovieViewModel>> GetByIds(int[] ids)
        {
            var movies = await movieDbSet.ToListAsync();
            return mapper.Map<List<MovieViewModel>>(movies);
        }
        public Task Create(MovieViewModel model)
        {
            movieDbSet.Add(mapper.Map<Movie>(model));

            return Task.CompletedTask;
        }
        public Task Update([FromRoute] int id, MovieViewModel model)
        {
            var movie = movieDbSet.FirstOrDefault(e => e.Id == id);

            movie.Name = model.Name;
            movie.Date = model.Date;

            return Task.CompletedTask;
        }
        public Task Delete(int[] ids)
        {
            var movies = movieDbSet.Where(e=>ids.Contains(e.Id)).ToList();
            movieDbSet.RemoveRange(movies);

            return Task.CompletedTask;
        }
    }
}
