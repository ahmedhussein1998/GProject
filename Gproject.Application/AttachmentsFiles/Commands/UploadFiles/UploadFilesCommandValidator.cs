using FluentValidation;
using Gproject.Application.AttachmentsFiles.Commands.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFiles
{
    public class UploadFilesCommandValidator : AbstractValidator<UploadFilesCommand>
    {
        public UploadFilesCommandValidator()
        {
            RuleFor(f => f.attachment).NotEmpty();
        }
    }
}
