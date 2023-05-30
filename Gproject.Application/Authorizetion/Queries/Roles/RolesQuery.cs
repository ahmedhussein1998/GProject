using ErrorOr;
using Gproject.Application.Authorizetion.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Gproject.Application.Authorizetion.Queries.Roles
{
    public record RolesQuery(
        ) : IRequest<ErrorOr<List<IdentityRole>>>;
}
