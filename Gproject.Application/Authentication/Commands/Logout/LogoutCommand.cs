using ErrorOr;
using MediatR;

namespace Gproject.Application.Authentication.Commands.Logout
{
    public record LogoutCommand(
        ) :IRequest<ErrorOr<string>>;


    

   
}
