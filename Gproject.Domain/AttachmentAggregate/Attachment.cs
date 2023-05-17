
using Gproject.Domain.Common.Models;

namespace Gproject.Domain.AttachmentAggregate
{
    public class Attachment : AuditableEntity<Guid>, IAggregateRoot
    {
        #region ctor
        private Attachment() : base()
        {
            if (Id == default)
                Id = Guid.NewGuid();
        }

        private Attachment(string attachmentName, string displayName, string extension,
            string contentType, double size, bool isActive = true, bool isDeleted = false) :this()
        {
            AttachmentName = attachmentName;
            DisplayName = displayName;
            Extension = extension;
            ContentType = contentType;
            Size = size;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }
        #endregion

        #region props
        public string AttachmentName { get; private set; }
        public string DisplayName { get; private set; }
        public string Extension { get; private set; }
        public double Size { get; private set; }
        public string ContentType { get; private set; }
        #endregion

        #region Creation
        public static Attachment Create(string attachmentName, string displayName, string extension,
            string contentType, double size)
        {
            return new (attachmentName, displayName, extension, contentType, size);
        }
        #endregion
    }
}
