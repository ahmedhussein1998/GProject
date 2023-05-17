using ErrorOr;
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
using Gproject.Application.AttachmentsFiles.Commands.UploadFiles;
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

        [NonAction]
        public byte[][] ConvertFilesToByteArrayArray(IList<IFormFile> files)
        {
            var byteArrayArray = new byte[files.Count][];
            for (int i = 0; i < files.Count; i++)
            {
                using (var memoryStream = new MemoryStream())
                {
                    files[i].CopyTo(memoryStream);
                    byteArrayArray[i] = memoryStream.ToArray();
                }
            }
            return byteArrayArray;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromForm] UploadFilesRequest request)
        {
            string[] ContantType = new string[50];
            string[] Extention = new string[50];
            double[] Size = new double[50];
            string[] displayName = new string[50];

            for (int i = 0; i < request.Files.Count; i++)
            {
                ContantType[i] = request.Files[i].ContentType;
                Extention[i] = Path.GetExtension(request.Files[i].FileName);
                Size[i] = (double)request.Files[i].Length / (1024.00 * 1024.00);
                ContantType[i] = request.Files[i].ContentType;
                displayName[i] = request.Files[i].FileName;
            }
            var commend = new UploadFilesCommand
           {
               attachment = ConvertFilesToByteArrayArray(request.Files),
               displayName = displayName,
               size = Size,
               contentType =ContantType,
               extension = Extention
            };
            var UploadFilesResult = await _mediator.Send(commend);
            return UploadFilesResult.Match(
            UploadFilesResult => Ok(_mapper.Map<ResponseFilesUpload>(UploadFilesResult)),
            errors => Problem(errors)
            );

        }
        //[HttpPost("DeletFile")]
        //public async Task<ErrorOr<ResponseFileUploaded>> DeletFile(string Path)
        //{           
        //    ErrorOr<ResponseFileUploaded> Result = await _filesService.DeleteFile (Path);
        //    return _mapper.Map<ResponseFileUploaded>(Result);
        //}

    }
}
