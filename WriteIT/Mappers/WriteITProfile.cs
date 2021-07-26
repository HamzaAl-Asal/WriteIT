using AutoMapper;
using WriteIT.Abstractions.Models;
using WriteIT.Data.Models;

namespace WriteIT.Mappers
{
    public class WriteITProfile : Profile
    {
        public WriteITProfile()
        {
            //Movies 
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
        }
    }
}



