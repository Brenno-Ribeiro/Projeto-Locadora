using MovieStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorAppService _directorAppService;

        public DirectorController(IDirectorAppService directorAppService)
        {
            _directorAppService = directorAppService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllDirectorsAsync()
        {
            var directors = await _directorAppService.GetAllDirectorsAsync();

            if (directors.Count.Equals(0))
            {
                return StatusCode(404, "Nenhum filme foi encontrado!");
            }

            return StatusCode(200, new { Directors = directors });
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirectorByIdAsync(Guid id)
        {
            var director = await _directorAppService.GetDirectorByIdAsync(id);

            if (director == null)
            {
                return StatusCode(404, $"Nenhum filme foi encontrado com o id: {id}");
            }

            return StatusCode(200, new { director = director });
        }
    }
}
