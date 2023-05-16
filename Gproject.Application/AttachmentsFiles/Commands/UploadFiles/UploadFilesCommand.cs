using ErrorOr;
using Gproject.Application.AttachmentsFiles.Common;
using Gproject.Application.Common.Interfaces.Services.Common;
using MediatR;


namespace Gproject.Application.AttachmentsFiles.Commands.UploadFiles
{
    //public record UploadFileCommand(
    //   byte[] attachment, string displayName, string contentType, string extension, double size) :IRequest<ErrorOr<ResponseFileUploaded>>;

    public class UploadFilesCommand : IRequest<ErrorOr<ResultFilesUpload>>
    {
        public byte[][]?attachment { get; set; }
        public string?[] contentType { get; set; }
        public string?[] displayName { get; set; }
        public string?[] extension { get; set; }
        public double[] size { get; set; }
    }

}
