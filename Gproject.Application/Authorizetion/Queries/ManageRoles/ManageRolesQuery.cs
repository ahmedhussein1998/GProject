using ErrorOr;
using Gproject.Application.Authorizetion.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authorizetion.Queries.User
{
    public record ManageRolesQuery(
        string userId) : IRequest<ErrorOr<UserRolesResult>>;
}
