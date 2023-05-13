using Gproject.Domain.Common.Exceptions;
using Gproject.Domain.Common.Models;
using Gproject.Domain.Common.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate.Entities;

namespace Gproject.Domain.MenuAggregate
{
    public sealed class Menu : AuditableEntity<Guid> , IAggregateRoot
    {

        private readonly List<MenuSection> _sections = new();
        //private readonly List<DinnerId> _dinner = new();
        //private readonly List<MenuReviewId> _menuReviewIds =new();
        public DescriptionLocalized Name { get; private set; }
        public DescriptionLocalized Description { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections;
        //public IReadOnlyList<DinnerId> DinnerIds => _dinner;
        //public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds;


        public Menu( DescriptionLocalized name, DescriptionLocalized description,
             List<MenuSection> sections, bool isActive = true, bool isDeleted = false) : this()  
        {
            
            Name= name; 
            Description= description;   
            _sections = sections;
            IsActive= isActive;
            IsDeleted= isDeleted;
          
        }
#pragma warning disable CS8618
        public Menu() :base()
        {
            if (Id == default)
                Id = Guid.NewGuid();


        }

        #region Behavior
        public static Menu Create(DescriptionLocalized name, DescriptionLocalized description, List<MenuSection> sections,bool isActive = true , bool isDeleted = false)
        {
            return new( name, description, sections??new(),isActive,isDeleted);
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
        public Menu Update(DescriptionLocalized name, DescriptionLocalized description, HostId hostId, List<MenuSection> sections, bool isActive , bool isDeleted )
        {
            Name = name;
            Description = description;

            if (sections != null)
            {
                _sections.Clear();
                _sections.AddRange(sections);
            }
            IsActive = isActive;
            IsDeleted = isDeleted;
            SetUpdate();

            return this;
        }



        #region MenuSection Behavior
        public void ActiveMenuSection(Guid menuSectionId)
        {
            var existedMenuSection = _sections.Single(c => c.Id == menuSectionId);
            // to do
            if (existedMenuSection == default)
                throw new MenuSectionDomainException("MenuSection not existed ");
            existedMenuSection.Activate();
        }

        public void DeactiveMenuSection(Guid menuSectionId)
        {
            var existedMenuSection = _sections.Single(c => c.Id == menuSectionId);
            // to do
            if (existedMenuSection == default)
                throw new MenuSectionDomainException("MenuSection not existed ");
            existedMenuSection.Deactivate();
        }

        public void RemoveMenuSection(Guid menuSectionId)
        {
            var existedMenuSection = _sections.Single(c => c.Id == menuSectionId);
            // to do
            if (existedMenuSection == default)
                throw new MenuSectionDomainException("MenuSection not existed ");
            existedMenuSection.Remove();
        }

        public void UpdateMenuSection(Guid menuSectionId, DescriptionLocalized name, DescriptionLocalized description, bool isActive)
        {
            if (_sections == default)
                throw new MenuSectionDomainException("can't modify empty data");

            var existedMenuSection = _sections.Single(c => c.Id == menuSectionId);
            // to do
            if (existedMenuSection == default)
                throw new MenuSectionDomainException("MenuSection not existed ");
            existedMenuSection.Update(  name,  description,  isActive);
        }




        #endregion

        #region MenuItem Behavior

        public void AddMenuItem(Guid menuSectionId, DescriptionLocalized name, DescriptionLocalized description, bool isActive)
        {
            var menuSection = _sections.FirstOrDefault(c => c.Id == menuSectionId);
            menuSection.AddMenuItem( name, description, isActive);
        }

        public void UpdateMenuItem(Guid menuSectionId,Guid menuItemId, DescriptionLocalized name, DescriptionLocalized description, bool isActive)
        {
            var menuSection = _sections.FirstOrDefault(c => c.Id == menuSectionId);
            menuSection.UpdateMenuItem(menuItemId, name, description, isActive);
        }


        public void ActiveMenuItem(Guid menuSectionId, Guid menuItemId)
        {
            var menuSection = _sections.FirstOrDefault(c => c.Id == menuSectionId);
            menuSection.ActiveMenuItem(menuItemId);
        }

        public void DeactiveMenuItem(Guid menuSectionId, Guid menuItemId)
        {
            var menuSection = _sections.FirstOrDefault(c => c.Id == menuSectionId);
            menuSection.DeactiveMenuItem(menuItemId);
        }

        public void RemoveMenuItem(Guid menuSectionId, Guid menuItemId)
        {
            var menuSection = _sections.FirstOrDefault(c => c.Id == menuSectionId);
            menuSection.RemoveMenuItem(menuItemId);
        }

        #endregion


        #endregion



#pragma warning restore CS8618
    }
}
