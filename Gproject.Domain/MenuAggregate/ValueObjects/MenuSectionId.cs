using Gproject.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        public static MenuSectionId CreateUnique()
        {
            return new (Guid.NewGuid());
        }
        public static MenuSectionId Create(Guid Value)
        {
            return new MenuSectionId(Value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
