using ErrorOr;
using Gproject.Application.Authentication.Common;
using Gproject.Application.Common;
using Gproject.Application.Menus.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Menus.Queries.GetAllMenus
{
    public record GetAllMenusQuery(string? Name,
        bool? IsActive,
         int PageIndex =0 ,
         int PageSize =10 ) : IRequest<ErrorOr<PaginatedList<GetAllMenusQueryResult>>>;
}
