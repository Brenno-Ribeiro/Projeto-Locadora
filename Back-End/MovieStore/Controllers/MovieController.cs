using MovieStore.Services.Interfaces;
using MovieStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace MovieStore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieAppService _movieAppService;
        private readonly IDirectorAppService _directorAppService;
        private readonly IImageAppService _imageAppService;

        public MovieController(IMovieAppService movieAppService, IDirectorAppService directorAppService, IImageAppService imageAppService)
        {
            _movieAppService = movieAppService;
            _directorAppService = directorAppService;
            _imageAppService = imageAppService;
        }

        /*
        [HttpGet("{letter}/{currentPage}")]
        public async Task<IActionResult> GetAllMoviesByLetterAsync(string letter = "A", int currentPage = 1)
        {

            var movies = await _movieAppService.GetAllMoviesByLetterAsync(letter);

            var paginationMetadate = new PaginationMetadata(currentPage, movies.Count, 12);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadate));

            movies.Skip((currentPage - 1) * 12)
                .Take(12)
                .ToList();


            if (movies.Count.Equals(0))
            {
                return StatusCode(404, "Nenhum filme foi encontrado!");
            }

            return StatusCode(200, new { Movies = movies });

        }*/

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {

            var movies = await _movieAppService.GetAllMovies();

            if (movies.Count.Equals(0))
            {
                return StatusCode(404, "Nenhum filme foi encontrado!");
            }

            return StatusCode(200, new { Movies = movies });

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieAppService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return StatusCode(404, $"Nenhum filme foi encontrado com o id: {id}");
            }

            return StatusCode(200, new { Movies = movie });
        }




        [HttpPost]
        public async Task<IActionResult> SaveMovieAsync(MovieRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Dados invalidos!");
            }

            await _directorAppService.SaveDirectorAsync(model.NameDirector, model.LastNameDirector);
            var directorId = _directorAppService.GetGuidDirectorByName(model.NameDirector, model.LastNameDirector);

            await _movieAppService.SaveMovieAsync(model, directorId);
            var movieId = _movieAppService.GetGuidMovieByName(model.Title);

            return StatusCode(200, new { movieId = movieId });
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(MovieUpdateRequestViewModel model, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Dados invalidos!");
            }

            await _movieAppService.UpdateMovieAsync(model, id);

            return StatusCode(200);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(Guid id)
        {
            var imageOfMovieExist = await _imageAppService.ImageOfMovieExist(id);

            if (imageOfMovieExist)
            {
                await _imageAppService.DeleteImageAsync(id);
            }

            var deleteMovieDone = await _movieAppService.DeleteMovieAsync(id);

            if (!deleteMovieDone)
            {
                StatusCode(500, "Um erro ocorreu, talvez esse id não exista!");
            }

            return Ok();
        }
    }
}
