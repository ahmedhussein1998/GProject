
using Gproject.contracts.DtoValidator;
using Microsoft.AspNetCore.Http;

namespace Gproject.contracts.UploadFIle
{
    public record FileDtoRequest
    {
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif", ".avif" })]
        [MaxFileSize(3 * 1024 * 1024)]
        public IFormFile File { get; init; }
    }


}
