using MovieStore.Context;
using MovieStore.Domain;
using MovieStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace MovieStore.Repositories
{
    public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(LocadoraContext context) : base(context)
        {

        }

        public Guid GetGuidDirectorByName(string nameDirector, string LastNameDirector)
        {
            return _context.Directors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name.Equals(nameDirector) && x.LastName.Equals(LastNameDirector))
                .Result.Id;
        }
    }
}
