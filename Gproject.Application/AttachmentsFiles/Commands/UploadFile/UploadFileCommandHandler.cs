using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.Common.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Application.Resources;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, ErrorOr<ResponseFileUploaded>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IUploadFilesService _filesService;

        public UploadFileCommandHandler( IStringLocalizer<SharedResources> stringLocalizer, IUploadFilesService filesService)
        {
            _stringLocalizer = stringLocalizer;
            _filesService = filesService;
        }

        public async Task<ErrorOr<ResponseFileUploaded>> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            //await Task.CompletedTask;
           
           
                var UploadedFileName = await _filesService.UploadFile(request.attachment, request.displayName);
                if (UploadedFileName != null)
                {
                    // insert in attachment table 
                }
                else
                {
                    // throw domain exciption Like return Errors.User.DuplicateEmail(_stringLocalizer);
                }


            return new ResponseFileUploaded(UploadedFileName, true, "File Uploaded successfully");
           
            
        }
    }
}
