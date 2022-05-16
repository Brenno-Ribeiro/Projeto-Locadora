using MovieStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Services.Interfaces
{
    public interface IMovieAppService
    {
        Task<List<MovieResponseViewModel>> GetAllMovies();
        Task<List<MovieResponseViewModel>> GetAllMoviesByLetterAsync(string letter);
        Task<MovieResponseViewModel> GetMovieByIdAsync(Guid id);
        Guid GetGuidMovieByName(string title);
        Task<bool> SaveMovieAsync(MovieRequestViewModel model, Guid directorId);
        Task<bool> UpdateMovieAsync(MovieUpdateRequestViewModel model, Guid id);
        Task<bool> DeleteMovieAsync(Guid id);
    }
}
