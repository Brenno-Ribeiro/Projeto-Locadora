using CloudinaryDotNet;

namespace MovieStore.Services.Interfaces
{
    public interface ICloudinaryAppService
    {
        Cloudinary InstantiateACloudinary();
    }
}
