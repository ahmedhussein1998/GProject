using Gproject.Domain.Common.Models;
using Gproject.Domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set;  }
        public string Description { get;  private set; }

        public IReadOnlyList<MenuItem> Items =>_items.ToList();
        private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> item) : base(menuSectionId)
        {
            Name= name;
            Description= description;
            _items = item;
        }
        public static MenuSection Create(string name, string description, List<MenuItem> item)
        {
            return new(MenuSectionId.CreateUnique(), name, description, item);
        }
        #pragma warning disable CS8618
        private MenuSection()
        {

        }
        #pragma warning restore CS8618
    }
}
