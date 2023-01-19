using Gproject.Domain.Common.Models;
using Gproject.Domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set;  }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
        #pragma warning disable CS8618
        private MenuItem()
        {

        }
        #pragma warning restore CS8618
    }
}
