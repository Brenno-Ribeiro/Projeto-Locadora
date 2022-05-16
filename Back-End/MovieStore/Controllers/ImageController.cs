using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ICloudinaryAppService _cloudinaryAppService;
        private readonly IImageAppService _imageAppService;

        public ImageController(ICloudinaryAppService cloudinaryAppService, IImageAppService imageAppService)
        {
            _cloudinaryAppService = cloudinaryAppService;
            _imageAppService = imageAppService;
        }


        [HttpPost]
        [Route("upload/{movieId}")]
        public async Task<IActionResult> UploadImage(IFormFile image, Guid movieId)
        {

            var imageOfMovieExist = await _imageAppService.ImageOfMovieExist(movieId);

            if (imageOfMovieExist)
            {
                return StatusCode(400, "Esse Filme já possui uma imagem!");
            }

            var cloudinary = _cloudinaryAppService.InstantiateACloudinary();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription($"{movieId}", image.OpenReadStream()),
                PublicId = movieId.ToString(),
            };

            var imageUploadResult = cloudinary.Upload(uploadParams);
            var movieDone = await _imageAppService.SaveImageAsync(imageUploadResult, movieId);

            if (!movieDone)
            {
                return StatusCode(400, "ocorreu um erro");
            }

            return StatusCode(200, "Imagem inserida");
        }
    }
}
