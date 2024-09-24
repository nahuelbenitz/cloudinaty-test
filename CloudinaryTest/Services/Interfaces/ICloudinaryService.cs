using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;

namespace CloudinaryTest.Services.Interfaces
{
    public interface ICloudinaryService
    {
        public Task<string> CargarImagen(IBrowserFile file, string name);
        public List<Resource> ListadoImages();
        public bool EliminarImagen(string publicId);
    }
}
