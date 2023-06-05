using Gproject.Domain.UserAggregate;

namespace Gproject.Application.Menus.Common
{
    public record GetAllMenusQueryResult(Guid id, string nameAr, string nameEn,bool isActive);


    public class GetAllMenusResult
    {
        public Guid Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsActive { get; set; }

        public GetAllMenusResult(Guid id, string nameAr, string nameEn, bool isActive)
        {
            Id = id;
            NameAr = nameAr;
            NameEn = nameEn;
            IsActive = isActive;
        }
    }

}
