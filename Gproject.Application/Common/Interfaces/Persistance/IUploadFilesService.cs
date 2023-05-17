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
        Task<string> UploadFile(byte[] file, string fileName, bool deleteOldFiles = false);

        Task InsertAttachmentInTable(Attachment attachment);

        Task<string[]> UploadFiles(byte[][] files, string[] fileName, bool deleteOldFiles = false);
        //Task<ErrorOr<ResponseFileUploaded>> DeleteFile(string path);
    }

}
