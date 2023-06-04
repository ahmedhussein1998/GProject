using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Menus.Common
{
    public record GetAllMenusQueryResult(Guid id, string nameAr, string nameEn,bool isActive);
    
}
