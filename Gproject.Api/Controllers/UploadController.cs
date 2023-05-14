using ErrorOr;
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
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
                var commend = _mapper.Map<UploadFileCommand>(request);
                var UploadFileResult = await _mediator.Send(commend);
                return UploadFileResult.Match(
                UploadFileResult => Ok(_mapper.Map<ResponseFileUpload>(UploadFileResult)),
                errors => Problem(errors)
                );
        }


        [HttpPost("UploadFiles")]
        public async Task<ErrorOr<ResponseFileUploaded>> UploadFiles([FromForm] List<IFormFile> options)
        {
            Random rnd = new Random();
            var path = $"\\Uploads\\Test\\Test_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
            ErrorOr<ResponseFileUploaded> Result = await _filesService.UploadFiles(path, options);
            return _mapper.Map<ResponseFileUploaded>(Result);
        }
        [HttpPost("DeletFile")]
        public async Task<ErrorOr<ResponseFileUploaded>> DeletFile(string Path)
        {           
            ErrorOr<ResponseFileUploaded> Result = await _filesService.DeleteFile (Path);
            return _mapper.Map<ResponseFileUploaded>(Result);
        }

    }
}
