//using ErrorOr;
//using Gproject.Application.Common.Interfaces.Authentication;
//using Gproject.Application.Common.Interfaces.Persistance;
//using MediatR;
//using Gproject.Domain.Common.Errors;
//using Gproject.Application.Authentication.Common;
//using Microsoft.Extensions.Localization;
//using Gproject.Domain.Common.Resources;
//using Microsoft.AspNetCore.Identity;
//using Gproject.Domain.UserAggregate;
//using System.ComponentModel.DataAnnotations;
//using Gproject.Application.Authentication.Queries.Login;
//using Gproject.Application.Menus.Queries.GetAllMenus;
//using Gproject.Infrastruct.Persistance;
//using Microsoft.EntityFrameworkCore;
//using Gproject.Application.Common;
//using Gproject.Application.Menus.Common;
//using Gproject.Application.Common.Mappings;

//namespace Gproject.Infrastruct.Queries.GetAllMenus
//{ 
//    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, ErrorOr<PaginatedList<GetAllMenusQueryResult>>>
//    {
        
//        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
//        private readonly GProjectDbContext _gprojectDbContext;

//        public GetAllMenusQueryHandler( IStringLocalizer<SharedResources> stringLocalizer, GProjectDbContext gprojectDbContext)
//        {
                
//                _stringLocalizer= stringLocalizer;
//            _gprojectDbContext = gprojectDbContext;
//        }
//        public async Task<ErrorOr<PaginatedList<GetAllMenusQueryResult>>> Handle(GetAllMenusQuery query, CancellationToken cancellationToken)
//        {
//            await Task.CompletedTask;

//            var Menu = _gprojectDbContext.Menus.AsNoTracking().AsQueryable();

//            if (!string.IsNullOrEmpty(query.Name))
//            {
//                Menu = Menu.Where(c => c.Name.DescriptionAr.Contains(query.Name)
//                    || c.Name.DescriptionEn.ToLower().Contains(query.Name.ToLower()));
//            }

//            if (query.IsActive is not null)
//            {
//                Menu = Menu.Where(c => c.IsActive == query.IsActive);
//            }

//            var paginatedList = await Menu.OrderBy(c => c.Name.DescriptionAr)
//               .Select(c => new GetAllMenusQueryResult(c.Id, c.Name.DescriptionAr, c.Name.DescriptionEn, c.IsActive))
//               .PaginatedListAsync(query.PageIndex, query.PageSize);

//            return paginatedList;

              
          
//        }
//    }
//}
