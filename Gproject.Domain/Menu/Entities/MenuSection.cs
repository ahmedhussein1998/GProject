using Gproject.Domain.Common.Models;
using Gproject.Domain.Menu.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items =>_items.ToList();
        private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
        {
            Name= name;
            Description= menuSectionId;
        }
        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, )
        }
    }
}
