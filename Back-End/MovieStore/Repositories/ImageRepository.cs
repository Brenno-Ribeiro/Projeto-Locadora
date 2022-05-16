using Microsoft.EntityFrameworkCore;
using MovieStore.Context;
using MovieStore.Domains;
using MovieStore.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieStore.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(LocadoraContext context) : base(context)
        {
        }

        public async Task<Image> GetImageBypublicId(Guid publicId)
        {
            return await _context.images
                .AsNoTracking()
                .FirstOrDefaultAsync(img => img.PublicId == publicId);
        }

        public async Task<bool> ImageOfMovieExist(Guid id)
        {
            return await _context.images
                .AsNoTracking()
                .AnyAsync(img => img.PublicId == id);
        }
    }
}
