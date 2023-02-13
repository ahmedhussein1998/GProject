using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.Models
{
    public abstract class AuditableEntity<Tkey> : Entity<Tkey> , ISoftDelete
    {
      
        public DateTimeOffset Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? LastModified { get; set; }
        public bool IsActive { get;  set; }
        public bool IsDeleted { get;  set; }

        public string LastModifiedBy { get; set; }
        internal void SetUpdate()
        {
            LastModified = DateTimeOffset.Now;
        }

    }
}
