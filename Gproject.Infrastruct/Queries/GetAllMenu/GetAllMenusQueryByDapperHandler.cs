using ErrorOr;
using MediatR;
using Microsoft.Extensions.Localization;
using Gproject.Domain.Common.Resources;
using Gproject.Application.Menus.Queries.GetAllMenus;
using Gproject.Application.Common;
using Gproject.Application.Menus.Common;
using Gproject.Application.Common.Interfaces.Services.Common;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Gproject.Infrastruct.Queries.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, ErrorOr<PaginatedList<GetAllMenusQueryResult>>>
    {
        
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetAllMenusQueryHandler( IStringLocalizer<SharedResources> stringLocalizer, ISqlConnectionFactory connectionFactory)
        {
                
                _stringLocalizer= stringLocalizer;
            _connectionFactory = connectionFactory;
        }
        public async Task<ErrorOr<PaginatedList<GetAllMenusQueryResult>>> Handle(GetAllMenusQuery query, CancellationToken cancellationToken)
        {

           await using SqlConnection sqlConnection = _connectionFactory
                .CreateConnection();

            var pageIndex = query.PageIndex > 0 ? query.PageIndex : 0;

            var result = await sqlConnection.QueryAsync(
    @"
        SELECT Id, NameAr, NameEn, IsActive 
        FROM Menus 
        WHERE (@Name IS NULL OR NameAr LIKE '%' + @Name + '%' OR LOWER(NameEn) LIKE '%' + LOWER(@Name) + '%')
        AND (@IsActive IS NULL OR IsActive = @IsActive)
        ORDER BY DescriptionAr 
        OFFSET @PageSize * @PageIndex ROWS 
        FETCH NEXT @PageSize ROWS ONLY;
    ",
    new
    {
        Name = query.Name,
        IsActive = query.IsActive,
        PageSize = query.PageSize,
        PageIndex = pageIndex
    }
);

           List<GetAllMenusQueryResult> resultList = result.Select(
               r => new GetAllMenusQueryResult(r.Id,
                                               r.NameAr,
                                               r.NameEn,
                                               r.IsActive)).ToList();



            var count = await sqlConnection.ExecuteScalarAsync<int>(
                @"
            SELECT COUNT(*) 
            FROM Menus 
            WHERE (@Name IS NULL OR NameAr LIKE '%' + @Name + '%' OR LOWER(NameEn) LIKE '%' + LOWER(@Name) + '%')
            AND (@IsActive IS NULL OR IsActive = @IsActive);
        ",
                new
                {
                    Name = query.Name,
                    IsActive = query.IsActive
                }
            );

            var paginatedList = new PaginatedList<GetAllMenusQueryResult>(resultList, count, pageIndex + 1, query.PageSize);

            return paginatedList;
        }
    }
}
