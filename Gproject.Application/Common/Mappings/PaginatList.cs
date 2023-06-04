using Microsoft.EntityFrameworkCore;

namespace Gproject.Application.Common.Mappings
{
    public class PaginatList<T> 
    {
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

    }
}
