using Gproject.Domain.Common.Models;
using Gproject.Domain.Common.ValueObjects;

namespace Gproject.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : AuditableEntity<Guid>
    {
        private readonly List<MenuItem> _items = new();
        public Menu Menu { get; set; }
        public DescriptionLocalized Name { get; private set;  }
        public DescriptionLocalized Description { get;  private set; }
        public Guid MenuId { get; private set; }

        public IReadOnlyList<MenuItem> Items =>_items.ToList();
        private MenuSection( DescriptionLocalized name, DescriptionLocalized description, List<MenuItem> item, bool isActive = true, bool isDeleted = false) : this()
        {
            Name= name;
            Description= description;
            _items = item;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
        public static MenuSection Create(DescriptionLocalized name, DescriptionLocalized description, List<MenuItem> item, bool isActive = true, bool isDeleted = false)
        {
            return new( name, description, item, isActive, isDeleted);
        }
        private MenuSection() :base()
        {
            if (Id == default)
                Id = Guid.NewGuid();

        }


        #region MenuSection Bahavior

        internal void Activate() => IsActive = true;
        internal void Deactivate() => IsActive = false;

        internal bool Remove()=> IsDeleted = true;

        internal void Update(DescriptionLocalized name, DescriptionLocalized description , bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
        #endregion

        #region MenuItem Behavior

        public void AddMenuItem( DescriptionLocalized name, DescriptionLocalized description, bool isActive = true,bool isDeleted =false)
        {
            _items.Add(MenuItem.Create(name, description, isActive, isDeleted));
        }

        public void UpdateMenuItem(Guid menuItemId, DescriptionLocalized name, DescriptionLocalized description, bool isActive)
        {
            var existedMenuItem = _items.Single(c => c.Id == menuItemId);
            //if (existedMenuItem == default)
            //    throw new MenuItemDomainException("MenuItem not existed ");
            existedMenuItem.Update(name,description,isActive);
        }


        public void ActiveMenuItem(Guid menuItemId)
        {
            var existedMenuItem = _items.Single(c => c.Id == menuItemId);
            //if (existedMenuItem == default)
            //    throw new MenuItemDomainException("MenuItem not existed ");
            existedMenuItem.Activate();
        }

        public void DeactiveMenuItem(Guid menuItemId)
        {
            var existedMenuItem = _items.Single(c => c.Id == menuItemId);
            //if (existedMenuItem == default)
            //    throw new MenuItemDomainException("MenuItem not existed ");
            existedMenuItem.Deactivate();
        }

        public void RemoveMenuItem(Guid menuItemId)
        {
            var existedMenuItem = _items.Single(c => c.Id == menuItemId);
            //if (existedMenuItem != null )
            //    throw new MenuItemDomainException("MenuItem not existed ");
            //if(existedMenuItem.IsDeleted == true)
            //    throw new MenuItemDomainException("MenuItem Is Already Deleted ");
            _items.Remove(existedMenuItem);
        }

        #endregion






    }
}
