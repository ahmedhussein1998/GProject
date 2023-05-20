using ErrorOr;
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
using Gproject.Application.AttachmentsFiles.Commands.UploadFiles;
using Gproject.Application.AttachmentsFiles.Queries.RemoveFile;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.contracts.UploadFIle;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UploadController : ApiController
    {
        private readonly IUploadFilesService _filesService;
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public UploadController(IHttpContextAccessor httpContextAccessor, IUploadFilesService filesService, IMapper mapper , IMediator mediator) :base(httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
            _filesService = filesService;
            _mapper= mapper;
            _mediator = mediator;
        }

        public IHttpContextAccessor HttpContextAccessor { get; }
        public IMediator Mediator { get; }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] FileDtoRequest request)
        {
            // var commend = _mapper.Map<UploadFileCommand>(request);
            var commend = new UploadFileCommand
            { 
                attachment = request.attachment,
                ServerRootPath = ServerRootPath
            };
            var UploadFileResult = await _mediator.Send(commend);
                return UploadFileResult.Match(
                UploadFileResult => Ok(_mapper.Map<ResponseFileUpload>(UploadFileResult)),
                errors => Problem(errors)
                );
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromForm] UploadFilesRequest request)
        {
            var commend = new UploadFilesCommand
            { 
                attachment = request.attachment,
                ServerRootPath = ServerRootPath
            };
            var UploadFilesResult = await _mediator.Send(commend);
            return UploadFilesResult.Match(
                   UploadFilesResult => Ok(_mapper.Map<ResponseFilesUpload>(UploadFilesResult)),
                   errors => Problem(errors)
            );
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletFile([FromRoute] Guid Id)
        {
            var Query = new RemoveFileQuery(Id);
            var DeletedFile =  await _mediator.Send(Query);
            return DeletedFile.Match(
                   DeletedFile => Ok(_mapper.Map<ResponseFilesDeleted>(DeletedFile)),
                   errors => Problem(errors)
           );
        }

    }
}
