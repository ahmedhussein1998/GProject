//using Gproject.Domain.Common.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Gproject.Domain.MenuAggregate.ValueObjects
//{
//    public sealed class MenuItemId : ValueObject
//    {
//        public Guid Value { get; }
//        private MenuItemId(Guid value)
//        {
//            Value = value;
//        }

//        public static MenuItemId CreateUnique()
//        {
//            return new(Guid.NewGuid());
//        }

//        public static MenuItemId Create(Guid Value)
//        {
//            return new MenuItemId(Value);
//        }
//        protected override IEnumerable<object> GetEqualityComponents()
//        {
//            yield return Value;
//        }
//    }
//}
