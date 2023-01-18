using Gproject.Domain.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Common.Interfaces.Persistance
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
