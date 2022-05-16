using MovieStore.Domain;
using MovieStore.ViewModels;
using AutoMapper;

namespace MovieStore.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Movie, MovieResponseViewModel>()
                .ForPath(dest => dest.NameDirector, opt => opt.MapFrom(opt => opt.Director.Name))
                .ForPath(dest => dest.LastNameDirector, opt => opt.MapFrom(opt => opt.Director.LastName))
                .ForPath(dest => dest.ImageLink, opt => opt.MapFrom(opt => opt.Image.SecureUrl));

            CreateMap<Director, DirectorResponseViewModel>();
        }
    }
}
