using AutoMapper;
using WriteIT.Abstractions.Models;
using WriteIT.Data.Models;

namespace WriteIT.Mappers
{
    public class WriteITProfile : Profile
    {
        public WriteITProfile()
        {
            //Movie 
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();

            //Series
            CreateMap<Series, SeriesViewModel>();
            CreateMap<SeriesViewModel, Series>();

            //Genre
            CreateMap<Genre, GenreViewModel>();
            CreateMap<GenreViewModel, Genre>();
        }
    }
}



