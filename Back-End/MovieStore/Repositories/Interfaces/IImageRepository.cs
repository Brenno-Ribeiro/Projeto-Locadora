using MovieStore.Domains;
using System;
using System.Threading.Tasks;

namespace MovieStore.Repositories.Interfaces
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<bool> ImageOfMovieExist(Guid id);
        Task<Image> GetImageBypublicId(Guid publicId);
    }
}
