using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CloudinaryTest.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace CloudinaryTest.Services
{
    public class CoudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;
        public CoudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;
            Account account = new Account(
                _configuration["Cloudinary:my_cloud_name"],
                _configuration["Cloudinary:my_api_key"],
                _configuration["Cloudinary:my_api_secret"]
            );
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public async Task<string> CargarImagen(IBrowserFile file, string name)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, file.OpenReadStream()),
                AssetFolder = "CloudinaryTest",
                PublicId = name
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            var imgUrl = uploadResult.SecureUrl.ToString();

            return imgUrl;
        }        

        public List<Resource> ListadoImages()
        {
            var resourceParams = new ImageUploadParams()
            {
                AssetFolder = "CloudinaryTest"
            };
            var resourceResult =  _cloudinary.ListResourcesByAssetFolder("CloudinaryTest");

            var hola = resourceResult.Resources.ToList();

            return hola;
        }

        public bool EliminarImagen(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var deleteResult = _cloudinary.Destroy(deleteParams);

            if (deleteResult != null)
                return true;
            

            return false;
        }
    }
}
