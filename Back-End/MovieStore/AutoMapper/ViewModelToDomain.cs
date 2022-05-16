using MovieStore.Domain;
using MovieStore.ViewModels;
using AutoMapper;
using CloudinaryDotNet.Actions;
using MovieStore.Domains;

namespace MovieStore.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<MovieRequestViewModel, Movie>();
            CreateMap<MovieRequestViewModel, Director>();
            CreateMap<ImageUploadResult, Image>();

            CreateMap<MovieUpdateRequestViewModel, Movie>()
                .ForMember(dest => dest.Title, opt => opt.Condition(src => (src.Title != "string")))
                .ForMember(dest => dest.ReleaseYear, opt => opt.Condition(src => (src.ReleaseYear != 0)))
                .ForMember(dest => dest.Duration, opt => opt.Condition(src => (src.Duration != "string")))
                .ForMember(dest => dest.Gender, opt => opt.Condition(src => (src.Gender != "string")))
                .ForMember(dest => dest.AgeGroup, opt => opt.Condition(src => (src.AgeGroup != "string")));
        }
    }
}

