using ErrorOr;
using Gproject.Application.Resources;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.Domain.AttachmentAggregate;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, ErrorOr<ResultFileUpload>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IUploadFilesService _filesService;

        public UploadFileCommandHandler( IStringLocalizer<SharedResources> stringLocalizer, IUploadFilesService filesService)
        {
            _stringLocalizer = stringLocalizer;
            _filesService = filesService;
        }

        public async Task<ErrorOr<ResultFileUpload>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            //await Task.CompletedTask;
           
           
            var UploadedFileName = await _filesService.UploadFile(request.attachment);
            if (UploadedFileName != null)
            {

                var attachment = Attachment.Create(request.attachment.FileName, Path.GetFileNameWithoutExtension(request.attachment.FileName), Path.GetExtension(request.attachment.FileName),
                    request.attachment.ContentType, request.attachment.Length, UploadedFileName);

                // insert in attachment table 
                await _filesService.InsertAttachmentInTable(attachment);

                if (UploadedFileName.StartsWith("\\"))
                {
                    if (!string.IsNullOrEmpty(UploadedFileName))
                    {
                        UploadedFileName = request.ServerRootPath + UploadedFileName.Replace('\\', '/');
                    }

                }
                return new ResultFileUpload(UploadedFileName);
            }
            else
            {
                // throw domain exciption Like return Errors.User.DuplicateEmail(_stringLocalizer);
            }

            return Error.Failure(code: "Failure", description: "Failure To Upload File");
        }
    }
}
