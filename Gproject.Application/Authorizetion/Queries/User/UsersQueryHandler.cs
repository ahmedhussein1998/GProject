using ErrorOr;
using Gproject.Application.Common.Interfaces.Persistance;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Microsoft.AspNetCore.Identity;
using Gproject.Domain.UserAggregate;

using Gproject.Application.Authorizetion.Common;
using Microsoft.EntityFrameworkCore;

namespace Gproject.Application.Authorizetion.Queries.User
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, ErrorOr<List<UserResult>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersQueryHandler(UserManager<ApplicationUser> userManager)
        {
                _userManager = userManager;
        }
        public async Task<ErrorOr<List<UserResult>>> Handle(UsersQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var users = await _userManager.Users
                .Select(user => new UserResult(user.Id, user.UserName, user.Email, _userManager.GetRolesAsync(user).Result))
                .ToListAsync();
            return users;


        }
    }
}
