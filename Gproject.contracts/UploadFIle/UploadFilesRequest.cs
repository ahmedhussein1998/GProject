using Gproject.contracts.DtoValidator;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.contracts.UploadFIle
{
    public record UploadFilesRequest
    {
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif", ".avif" })]
        [MaxFileSize(3 * 1024 * 1024)]
        public IList<IFormFile> Files { get; init; }
    }
}
