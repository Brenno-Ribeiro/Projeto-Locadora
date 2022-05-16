using CloudinaryDotNet.Actions;
using MovieStore.Domains;
using System;
using System.Threading.Tasks;


namespace MovieStore.Services.Interfaces
{
    public interface IImageAppService
    {
        Task<bool> SaveImageAsync(ImageUploadResult imageUploadResult, Guid movieId);
        Task<bool> ImageOfMovieExist(Guid id);
        Task<Image> GetImageBypublicId(Guid publicId);
        Task<bool> DeleteImageAsync(Guid id);   
    }
}
