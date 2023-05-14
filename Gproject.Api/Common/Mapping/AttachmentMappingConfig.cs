
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
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
                .Map(dest => dest.size, src => (double)src.File.Length / (1024.00 * 1024.00))
                .Map(dest => dest.displayName, src => src.File.FileName)
                .Map(dest => dest.contentType, src => Path.GetExtension(src.File.ContentType))
                .Map(dest => dest.attachment, src => GetFileBytes(src.File));



            config.NewConfig<ResponseFileUploaded, ResponseFileUpload>()
                .Map(dest => dest.SavedName, src => src.SavedName);
        }


        public static byte[] GetFileBytes(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        } 
    }
}
