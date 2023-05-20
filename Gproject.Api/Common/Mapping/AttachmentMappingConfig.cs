
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
using Gproject.Application.AttachmentsFiles.Commands.UploadFiles;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.contracts.UploadFIle;
using Mapster;

namespace Gproject.Api.Common.Mapping
{
    public class AttachmentMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<FileDtoRequest, UploadFileCommand>()
                .Map(dest => dest.attachment, src => src.attachment);
            //config.NewConfig<UploadFilesRequest, UploadFilesCommand>();
        }

    }
}
