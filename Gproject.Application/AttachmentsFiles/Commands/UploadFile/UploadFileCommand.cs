using ErrorOr;
using Gproject.Application.Common.Interfaces.Services.Common;
using MediatR;


namespace Gproject.Application.AttachmentsFiles.Commands.UploadFile
{
    public record UploadFileCommand(
       byte[] attachment, string displayName, string contentType, string extension, double size) :IRequest<ErrorOr<ResponseFileUploaded>>;

}
