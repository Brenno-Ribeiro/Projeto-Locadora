using MovieStore.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Repositories.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetAllMoviesByLetterAsync(string letter);
        Task<IEnumerable<Movie>> GetAllMovies();
        Guid GetGuidMovieByName(string title);
        Task<Movie> GetMovieByIdAsync(Guid id);
    }
}
