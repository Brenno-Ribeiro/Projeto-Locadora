using MovieStore.Domain;
using System;

namespace MovieStore.Repositories.Interfaces
{
    public interface IDirectorRepository : IBaseRepository<Director>
    {
        Guid GetGuidDirectorByName(string nameDirector, string LastNameDirector);
    }
}
