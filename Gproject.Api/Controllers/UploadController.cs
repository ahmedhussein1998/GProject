using ErrorOr;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Common.Interfaces.Services;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.contracts.Authentication;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public UploadController(IHttpContextAccessor httpContextAccessor, IUploadFilesService filesService, IMapper mapper) :base(httpContextAccessor)
        {
            _filesService= filesService;
            _mapper= mapper;
        }
        [HttpPost]

        public async Task<ErrorOr<ResponseFileUploaded>> UploadFile([FromForm] IFormFile options)
        {
            Random rnd = new Random();
            var path = $"\\Uploads\\Test\\Test_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Second}_{rnd.Next(9000)}";
            ErrorOr<ResponseFileUploaded> Result =await _filesService.UploadFile(path,options);
            return _mapper.Map<ResponseFileUploaded>(Result);
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
