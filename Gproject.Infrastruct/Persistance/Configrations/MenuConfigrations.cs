using Gproject.Domain.DinnerAggregate.ValueObjects;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.MenuAggregate.Entities;
using Gproject.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class MenuConfigrations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenuTable(builder);
            ConfigureMenuSections(builder);
            ConfigureMenuDinnerIds(builder);
            ConfigureMenuReviewIds(builder);
        }

        private void ConfigureMenuReviewIds(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, Mrb =>
            {
                Mrb.ToTable("MenuReviewIds");
                Mrb.WithOwner().HasForeignKey("MenuId");
                Mrb.HasKey("Id");
                Mrb.Property(x => x.Value).HasColumnName("MenuReviewId").ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIds(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, Db =>
            {
                Db.ToTable("MenuDinnerIds");
                Db.WithOwner().HasForeignKey("MenuId");
                Db.HasKey("Id");
                Db.Property(x => x.Value).HasColumnName("DinnerId").ValueGeneratedNever();
            });
            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuSections(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");
                sb.Property(x => x.Id).HasColumnName("MenuSectionId").ValueGeneratedNever().HasConversion(
                        id=>id.Value,
                        value=> MenuSectionId.Create(value)
                    );
                sb.Property(x => x.Description).HasMaxLength(500);
                sb.Property(x => x.Name).HasMaxLength(200);
                sb.OwnsMany(s => s.Items, ib =>
                {
                    ib.ToTable("MenuItems");
                    ib.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
                    ib.HasKey(nameof(MenuItem.Id),"MenuSectionId", "MenuId");
                    ib.Property(i => i.Id).HasColumnName("MenuItemId").ValueGeneratedNever().HasConversion(
                        id => id.Value,
                        value => MenuItemId.Create(value));
                    ib.Property(i => i.Name).HasMaxLength(200);
                    ib.Property(i => i.Description).HasMaxLength(500);
                });
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            });
            builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(id => id.Value, value => MenuId.Create(value));
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.OwnsOne(x => x.AverageRating);
            builder.Property(x => x.HostId).HasConversion(id => id.Value, value => HostId.Create(value));
            builder.Property(x => x.CreatededDateTime).HasColumnType("DateTime");
            builder.Property(x => x.UpdatedDateTime).HasColumnType("DateTime");
        }
    }
}
