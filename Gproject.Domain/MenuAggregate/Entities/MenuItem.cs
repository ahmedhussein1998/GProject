using Gproject.Domain.Common.Models;
using Gproject.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : AuditableEntity<Guid>
    {
        private MenuItem( DescriptionLocalized name, DescriptionLocalized description, bool isActive = true, bool isDeleted = false) : this()
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        public DescriptionLocalized Name { get; private set; }
        public DescriptionLocalized Description { get; private set;  }
        public MenuSection Section { get; private set; }
        public Guid MenuSectionId { get; private set; }
        private MenuItem():base()
        {
            if (Id == default) 
                Id = Guid.NewGuid();
        }
        #region Behavior
        public static MenuItem Create(DescriptionLocalized name, DescriptionLocalized description, bool isActive = true, bool isDeleted = false)
        {
            return new( name, description, isActive, isDeleted );
        }
        #pragma warning disable CS8618

    
        internal void Activate() => IsActive = true;
        internal void Deactivate() => IsActive = false;
        internal void Remove() => IsActive = false;

        internal void Update(DescriptionLocalized name, DescriptionLocalized description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
        #endregion

#pragma warning restore CS8618
    }
}
