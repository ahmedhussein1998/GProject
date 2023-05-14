using ErrorOr;
using Gproject.Application.Common.Interfaces.Services.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Interfaces.Services
{
    public interface IUploadFilesService
    {
        Task<ErrorOr<ResponseFileUploaded>> UploadFile(string path, IFormFile file, bool deleteOldFiles = false);
        Task<ErrorOr<ResponseFileUploaded>> UploadFiles(string path, List<IFormFile> files, bool deleteOldFiles = false);
        Task<ErrorOr<ResponseFileUploaded>> DeleteFile(string path);
    }

}
