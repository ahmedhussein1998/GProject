using Gproject.Application.Common.Interfaces.Persistance;
using Gproject.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menu = new();
        public void Add(Menu menu)
        {
            _menu.Add(menu);        
        }
    }
}
