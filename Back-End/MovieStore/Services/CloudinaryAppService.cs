using MovieStore.Services.Interfaces;
using CloudinaryDotNet;
using Microsoft.Extensions.Configuration;

namespace MovieStore.Services
{
    public class CloudinaryAppService : ICloudinaryAppService
    {
        private IConfiguration _configuration;

        public CloudinaryAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Cloudinary InstantiateACloudinary()
        {
            return new Cloudinary(_configuration.GetSection("Cloudinary:Key").Value);
        }
    }
}
