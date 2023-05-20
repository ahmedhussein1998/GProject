using ErrorOr;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.Domain.AttachmentAggregate;
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
        Task<string> UploadFile(IFormFile file, bool deleteOldFiles = false);
        Task InsertAttachmentInTable(Attachment attachment);
        Task RemoveFileFormTable(Guid Id);
        Task<string[]> UploadFiles(IList<IFormFile> files, bool deleteOldFiles = false);
        Task<Attachment>? GetFileAttachment(Guid Id);
        Task<bool> DeleteFilePhysical(string path);
    }

}
