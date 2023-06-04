using ErrorOr;
using Gproject.Application.Menus.Common;
using MediatR;

namespace Gproject.Application.Menus.Queries.GetMenuById
{
    public record GetMenuByIdQuery(Guid id) : IRequest<ErrorOr<GetMenuByIdQueryResult>>;
}
