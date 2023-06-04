using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Menus.Common
{
    public record GetMenuByIdQueryResult(Guid id, string nameAr, string nameEn,bool isActive);
    
}
