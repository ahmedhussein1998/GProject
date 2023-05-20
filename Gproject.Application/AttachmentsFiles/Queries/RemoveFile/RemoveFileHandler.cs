using ErrorOr;
using Gproject.Application.AttachmentsFiles.Common;
using Gproject.Application.Common.Interfaces.Services;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Errors;
using Gproject.Domain.Common.Resources;

namespace Gproject.Application.AttachmentsFiles.Queries.RemoveFile
{
    public class RemoveFileHandler : IRequestHandler<RemoveFileQuery, ErrorOr<ResultFileRemove>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IUploadFilesService _filesService;
        public RemoveFileHandler(IStringLocalizer<SharedResources> stringLocalizer, IUploadFilesService filesService)
        {
            _stringLocalizer = stringLocalizer;
            _filesService = filesService;
        }
        public async Task<ErrorOr<ResultFileRemove>> Handle(RemoveFileQuery request, CancellationToken cancellationToken)
                {
            //1. Validata User Dose Exist
            var File = _filesService.GetFileAttachment(request.Id);
            if (File.Result is null)
            {
                return Errors.Files.NotFound(_stringLocalizer);
            }
            await _filesService.RemoveFileFormTable(File.Result.Id);
            await _filesService.DeleteFilePhysical(File.Result.PathSaved);
            return new ResultFileRemove (true);
        }
    }
}
