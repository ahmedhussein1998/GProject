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
using Gproject.Application.AttachmentsFiles.Common;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFiles
{
    public class UploadFilesCommandHandler : IRequestHandler<UploadFilesCommand, ErrorOr<ResultFilesUpload>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IUploadFilesService _filesService;

        public UploadFilesCommandHandler( IStringLocalizer<SharedResources> stringLocalizer, IUploadFilesService filesService)
        {
            _stringLocalizer = stringLocalizer;
            _filesService = filesService;
        }

        public async Task<ErrorOr<ResultFilesUpload>> Handle(UploadFilesCommand request, CancellationToken cancellationToken)
        {
            //await Task.CompletedTask;
           
           
                var UploadedFilesName = await _filesService.UploadFiles(request.attachment, request.displayName);
                if (UploadedFilesName != null)
                {
                    // insert in attachment table 
                    return new ResultFilesUpload(UploadedFilesName);
                }
                else
                {
                    // throw domain exciption Like return Errors.User.DuplicateEmail(_stringLocalizer);
                }
            return Error.Failure(code: "Failure", description: "Failure To Upload Files");

        }
    }
}
