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
    public class MovieAppService : IMovieAppService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieAppService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieResponseViewModel>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllMovies();
            var movieReponse = new List<MovieResponseViewModel>();

            foreach (var item in movies)
            {
                movieReponse.Add(_mapper.Map<MovieResponseViewModel>(item));
            }

            return movieReponse;
        }

        public async Task<List<MovieResponseViewModel>> GetAllMoviesByLetterAsync(string letter)
        {
            var movies = await _movieRepository.GetAllMoviesByLetterAsync(letter);
            var movieReponse = new List<MovieResponseViewModel>();

            foreach (var item in movies)
            {
                movieReponse.Add(_mapper.Map<MovieResponseViewModel>(item));
            }

            return movieReponse;
        }

     
        public async Task<MovieResponseViewModel> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            return _mapper.Map<MovieResponseViewModel>(movie);
        }


        public async Task<bool> SaveMovieAsync(MovieRequestViewModel model, Guid directorId)
        {
            var movie = _mapper.Map<Movie>(model);
            movie.DirectorId = directorId;
            return await _movieRepository.SaveAsync(movie);
        }


        public async Task<bool> UpdateMovieAsync(MovieUpdateRequestViewModel model, Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            _mapper.Map(model, movie);
            return await _movieRepository.UpdateAsync(movie);
        }


        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return await _movieRepository.DeleteAsync(movie);
        }

        public Guid GetGuidMovieByName(string title)
        {
            return _movieRepository.GetGuidMovieByName(title);
        }

       
    }
}
