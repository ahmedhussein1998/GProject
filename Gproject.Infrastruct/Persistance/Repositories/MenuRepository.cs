using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GProjectDbContext _context;

        public MenuRepository(GProjectDbContext context)
        {
            _context = context;
        }

        private static readonly List<Menu> _menu = new();
        public async Task Add(Menu menu)
        {
            _context.Menus.Add(menu);
            await  _context.SaveEntitiesAsync();

        }
    }
}
