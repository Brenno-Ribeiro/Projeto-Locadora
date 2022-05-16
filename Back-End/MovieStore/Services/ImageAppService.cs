using AutoMapper;
using CloudinaryDotNet.Actions;
using MovieStore.Domains;
using MovieStore.Repositories.Interfaces;
using MovieStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieStore.Services
{
    public class ImageAppService : IImageAppService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICloudinaryAppService _cloudinaryAppService;
        private readonly IMapper _mapper;

        public ImageAppService(IImageRepository imageRepository, ICloudinaryAppService cloudinaryAppService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _cloudinaryAppService = cloudinaryAppService;
            _mapper = mapper;
        }

        public async Task<Image> GetImageBypublicId(Guid publicId)
        {
            return await _imageRepository.GetImageBypublicId(publicId);
        }

        public async Task<bool> ImageOfMovieExist(Guid id)
        {
            return await _imageRepository.ImageOfMovieExist(id);
        }

        public async Task<bool> SaveImageAsync(ImageUploadResult imageUploadResult, Guid movieId)
        {
            var image = _mapper.Map<Image>(imageUploadResult);
            image.MovieId = movieId;
            return await _imageRepository.SaveAsync(image);
        }
    
        public async Task<bool> DeleteImageAsync(Guid id)
        {
            var cloudinary = _cloudinaryAppService.InstantiateACloudinary();

            var delResParams = new DelResParams()
            {
                PublicIds = new List<string> { id.ToString() },
                ResourceType = ResourceType.Image,
            };
            cloudinary.DeleteResources(delResParams);

            var image = await GetImageBypublicId(id);
            return await _imageRepository.DeleteAsync(image);   
        }
    }
}
