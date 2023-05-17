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
           
           
            var UploadedFileName = await _filesService.UploadFile(request.attachment, request.displayName);
            if (UploadedFileName != null)
            {

                var attachment = Attachment.Create(UploadedFileName, request.displayName, request.extension,
                    request.contentType, request.size);

                await _filesService.InsertAttachmentInTable(attachment);
                // insert in attachment table 
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
