using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.AttachmentsFiles.Commands.UploadFile
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileCommandValidator()
        {
        }
    }
}
