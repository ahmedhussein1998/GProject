using Gproject.Domain.AttachmentAggregate;
using Gproject.Domain.HostAggregate.ValueObjects;
using Gproject.Domain.MenuAggregate;
using Gproject.Infrastruct.Persistance.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gproject.Infrastruct.Persistance.Configrations
{
    public class AttachmentConfigrations : AuditableEntityTypeConfiguration<Attachment, Guid>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {

            ConfigureAttachmentTable(builder);
        }

     

        private void ConfigureAttachmentTable(EntityTypeBuilder<Attachment> builder)
        {
            base.Configure(builder);
            builder.ToTable("Attachments");
            builder.HasKey(x => x.Id);

            builder.Property(a => a.AttachmentName)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(a => a.DisplayName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.ContentType)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(a => a.Extension)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(a => a.Size)
               .HasColumnType("decimal(19,4)")
               .IsRequired();
            builder.Property(a => a.PathSaved)
                .IsRequired();
        }
    }
}
