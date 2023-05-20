using ErrorOr;
using Gproject.Application.Common.Interfaces.Services.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFile
{
    //public record UploadFileCommand(
    //   byte[] attachment, string displayName, string contentType, string extension, double size) :IRequest<ErrorOr<ResponseFileUploaded>>;

    public class UploadFileCommand : IRequest<ErrorOr<ResultFileUpload>>
    {
        public IFormFile attachment { get; set; }
        public string ServerRootPath {get;set;}
    }

}
