using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Infrastruct.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class MenuConfigrations : AuditableEntityTypeConfiguration<Menu,Guid>
    {
        public override void Configure(EntityTypeBuilder<Menu> builder)
        {
            
            ConfigureMenuTable(builder);
            //ConfigureMenuSections(builder);
            //ConfigureMenuDinnerIds(builder);
            //ConfigureMenuReviewIds(builder);
        }

        //private void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
        //{
        //    builder.OwnsMany(m => m.MenuReviewIds, Mrb =>
        //    {
        //        Mrb.ToTable("MenuReviewIds");
        //        Mrb.WithOwner().HasForeignKey("MenuId");
        //        Mrb.HasKey("Id");
        //        Mrb.Property(x => x.Value).HasColumnName("MenuReviewId").ValueGeneratedNever();
        //    });
        //    builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        //}

        //private void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
        //{
        //    builder.OwnsMany(m => m.DinnerIds, Db =>
        //    {
        //        Db.ToTable("MenuDinnerIds");
        //        Db.WithOwner().HasForeignKey("MenuId");
        //        Db.HasKey("Id");
        //        Db.Property(x => x.Value).HasColumnName("DinnerId").ValueGeneratedNever();
        //    });
        //    builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        //}


        private void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
       
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

            builder.HasMany(x => x.Sections)
                .WithOne(x => x.Menu)
                .HasForeignKey(x => x.MenuId);

           builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);


        }
    }
}
