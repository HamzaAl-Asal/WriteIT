using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Data;
using WriteIT.Interfaces;

namespace WriteIT.Services
{
    public class GenreService : IGenre
    {
        private readonly IMapper mapper;
        private readonly WriteITContext dbContext;
        public GenreService(IMapper mapper, WriteITContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public async Task<List<GenreViewModel>> Get()
        {
             return mapper.Map<List<GenreViewModel>>(await dbContext.Genre.ToListAsync());
        }
    }
}
