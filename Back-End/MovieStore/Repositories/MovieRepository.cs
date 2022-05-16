using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MovieStore.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(LocadoraContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies
                .Include("Director")
                .Include("Image")
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesByLetterAsync(string letter)
        {
            return await _context.Movies
                .Include("Director")
                .Include("Image")
                .Where(movie => movie.Title.ToUpper().StartsWith(letter))
                .ToListAsync();
        }

        
        public Guid GetGuidMovieByName(string title)
        {
            return _context.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Title == title)
                .Result
                .Id;
        }

        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _context.Movies
               .Include("Director")
               .Include("Image")
               .AsNoTracking()
               .FirstOrDefaultAsync(movie => movie.Id == id);
        }
    }
}
