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

        public string Name { get; }
        public string Description { get; }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
