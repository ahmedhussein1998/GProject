using ErrorOr;
using Gproject.Application.AttachmentsFiles.Common;
using Gproject.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.AttachmentsFiles.Queries.RemoveFile
{
    public record RemoveFileQuery(Guid Id) : IRequest<ErrorOr<ResultFileRemove>>;
}
