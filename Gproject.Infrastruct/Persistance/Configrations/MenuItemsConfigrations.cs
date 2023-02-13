
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Infrastruct.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class MenuItemsConfigrations : AuditableEntityTypeConfiguration<MenuItem, Guid>
    {
        public override void Configure(EntityTypeBuilder<MenuItem> builder)
        {

            base.Configure(builder);
            builder.ToTable("MenuItems");

            builder.OwnsOne(x => x.Name, n =>
            {
                n.Property(n => n.DescriptionAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                n.Property(n => n.DescriptionEn).HasColumnName("NameEn").HasMaxLength(50);
            });
            builder.OwnsOne(s => s.Description, c =>
            {
                c.Property(n => n.DescriptionAr).HasColumnName("DescriptionAr");
                c.Property(n => n.DescriptionEn).HasColumnName("DescriptionEn");
            });

        }

    }
}


