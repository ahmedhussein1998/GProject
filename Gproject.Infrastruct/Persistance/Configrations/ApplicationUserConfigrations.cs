using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Domain.UserAggregate;
using Gproject.Infrastruct.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class ApplicationUserConfigrations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {


            builder.OwnsOne(c => c.FullName, builder =>
            {
                builder.Property(n => n.FirstName)
                     .IsRequired()
                    .HasColumnName("First Name")
                     .HasMaxLength(30);

                builder.Property(n => n.LastName)
                    .IsRequired()
                    .HasColumnName("Last Name")
                    .HasMaxLength(30);
            });


            builder.OwnsOne(c => c.Phone, builder =>
            {
                builder.Property(n => n.CountryPrefix)
                     .IsRequired(false)
                    .HasColumnName("Phone Country Prefix")
                     .HasMaxLength(5);

                builder.Property(n => n.Number)
                    .IsRequired(false)
                    .HasColumnName("Phone Number")
                    .HasMaxLength(10);
            });


            builder.OwnsOne(s => s.Nationality, c =>
            {
                c.Property(n => n.Code)
                .HasColumnName("NationalityCode")
                .IsRequired()
                .HasMaxLength(20);

                c.Property(n => n.DescriptionAr)
                .HasColumnName("NationalityNameAr")
                .HasMaxLength(20);

                c.Property(n => n.DescriptionEn)
              .HasColumnName("NationalityNameEn")
              .HasMaxLength(20);
            });


            builder.OwnsOne(s => s.Gender, c =>
            {
                c.Property(n => n.Code)
                .HasColumnName("GenderCode")
                .IsRequired()
                .HasMaxLength(20);

                c.Property(n => n.DescriptionAr)
                .HasColumnName("GenderNameAr")
                .HasMaxLength(10);

                c.Property(n => n.DescriptionEn)
                .HasColumnName("GenderNameEn")
                .HasMaxLength(10);


            });



        }

    }
}
