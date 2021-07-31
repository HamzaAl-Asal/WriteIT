using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WriteIT.Abstractions.Models;
using WriteIT.Data;
using WriteIT.Data.Models;

namespace WriteIT.Services
{
    public class GenreService
    {
        private readonly IMapper mapper;
        private readonly DbSet<Genre> genreDbSet;
        public GenreService(IMapper mapper, WriteITContext context)
        {
            this.mapper = mapper;
            this.genreDbSet = context.Set<Genre>();
        }

        public async Task<List<GenreViewModel>> Get()
        {
            return mapper.Map<List<GenreViewModel>>(await genreDbSet.ToListAsync());
        }
    }
}
