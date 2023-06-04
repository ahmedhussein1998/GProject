

namespace Gproject.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

      


    }
}
