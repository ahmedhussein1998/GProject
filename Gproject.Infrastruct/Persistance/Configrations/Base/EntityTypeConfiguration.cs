using Gproject.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Infrastruct.Persistance.Configurations.Base
{
    public class EntityTypeConfiguration<T, TKey> : IEntityTypeConfiguration<T>
         where T : Entity<TKey>
         where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

        }
    }
}
