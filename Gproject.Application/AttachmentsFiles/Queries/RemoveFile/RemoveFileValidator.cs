using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.AttachmentsFiles.Queries.RemoveFile
{
    public class RemoveFileValidator :AbstractValidator<RemoveFileQuery>
    {
        public RemoveFileValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
