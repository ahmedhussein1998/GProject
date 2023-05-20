using ErrorOr;
using Gproject.Application.AttachmentsFiles.Common;
using Gproject.Application.Common.Interfaces.Services.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFiles
{
    //public record UploadFileCommand(
    //   byte[] attachment, string displayName, string contentType, string extension, double size) :IRequest<ErrorOr<ResponseFileUploaded>>;

    public class UploadFilesCommand : IRequest<ErrorOr<ResultFilesUpload>>
    {
        public IList<IFormFile> attachment { get; set; }
        public string? ServerRootPath { get; set; }
    }

}
