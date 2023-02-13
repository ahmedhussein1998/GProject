using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Infrastruct.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class MenuSectionsConfigrations : AuditableEntityTypeConfiguration<MenuSection, Guid>
    {
        public override void Configure(EntityTypeBuilder<MenuSection> builder)
        {

            base.Configure(builder);
            builder.ToTable("MenuSections");
            //builder.Property(x => x.Id).HasConversion(id => id, value => MenuId.Create(value));

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

            builder.HasMany(x => x.Items)
                .WithOne(x => x.Section)
                .HasForeignKey(x => x.MenuSectionId);


            builder.Navigation(s => s.Items).Metadata.SetField("_items");
            builder.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
     


    }
}


