using MovieStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Services.Interfaces
{
    public interface IDirectorAppService
    {
        Task<List<DirectorResponseViewModel>> GetAllDirectorsAsync();
        Task<DirectorResponseViewModel> GetDirectorByIdAsync(Guid id);
        Task<bool> SaveDirectorAsync(string nameDirector, string LastNameDirector);
        Guid GetGuidDirectorByName(string nameDirector, string LastNameDirector);
    }
}
