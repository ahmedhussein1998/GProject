
using Gproject.Application.AttachmentsFiles.Commands.UploadFile;
using Gproject.Application.AttachmentsFiles.Commands.UploadFiles;
using Gproject.Application.Common.Interfaces.Services.Common;
using Gproject.Application.Emails.Commands.SendEmail;
using Gproject.contracts.Menus;
using Gproject.contracts.UploadFIle;
using Mapster;

namespace Gproject.Api.Common.Mapping
{
    public class MailMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SendEmailRequest, SendEmailCommand>();
            //config.NewConfig<UploadFilesRequest, UploadFilesCommand>();
        }
 
    }
}
