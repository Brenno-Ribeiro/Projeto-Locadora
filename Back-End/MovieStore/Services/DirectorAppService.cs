using MovieStore.Domain;
using MovieStore.Repositories.Interfaces;
using MovieStore.Services.Interfaces;
using MovieStore.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieStore.Services
{
    public class DirectorAppService : IDirectorAppService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorAppService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<List<DirectorResponseViewModel>> GetAllDirectorsAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            var directorResponse = new List<DirectorResponseViewModel>();

            foreach (var item in directors)
            {
                directorResponse.Add(_mapper.Map<DirectorResponseViewModel>(item));
            }

            return directorResponse;
        }

        public async Task<DirectorResponseViewModel> GetDirectorByIdAsync(Guid id)
        {
            var director = await _directorRepository.GetByIdAsync(id);
            return _mapper.Map<DirectorResponseViewModel>(director);
        }

        public Guid GetGuidDirectorByName(string nameDirector, string LastNameDirector)
        {
            return _directorRepository.GetGuidDirectorByName(nameDirector, LastNameDirector);
        }


        public async Task<bool> SaveDirectorAsync(string nameDirector, string LastNameDirector)
        {
            var director = new Director
            {
                Name = nameDirector,
                LastName = LastNameDirector
            };

            return await _directorRepository.SaveAsync(director);
        }
    }
}
