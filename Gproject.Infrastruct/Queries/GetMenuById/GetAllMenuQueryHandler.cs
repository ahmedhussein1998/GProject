using ErrorOr;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Gproject.Application.Menus.Queries.GetMenuById;
using Gproject.Infrastruct.Persistance;
using Microsoft.EntityFrameworkCore;
using Gproject.Domain.Common.Errors;
using Gproject.Application.Menus.Common;

namespace Gproject.Infrastruct.Queries.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, ErrorOr<GetMenuByIdQueryResult>>
    {
        
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly GProjectDbContext _gprojectDbContext;

        public GetMenuByIdQueryHandler( IStringLocalizer<SharedResources> stringLocalizer, GProjectDbContext gprojectDbContext)
        {
                
            _stringLocalizer= stringLocalizer;
            _gprojectDbContext = gprojectDbContext;
        }
        public async Task<ErrorOr<GetMenuByIdQueryResult>> Handle(GetMenuByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var menus = await _gprojectDbContext.Menus.Where(x=>x.Id == query.id).Select(c => new GetMenuByIdQueryResult(c.Id, c.Name.DescriptionAr, c.Name.DescriptionEn, c.IsActive)).FirstOrDefaultAsync();

            if (menus == null)
            {
                return Errors.Menu.NotFound(_stringLocalizer);

            }

            return menus;

              
          
        }
    }
}
