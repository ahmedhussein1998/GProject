using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.Models
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType()) return false;
            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
        public static bool operator == (ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
        }

        public bool Equals(ValueObject? other)
        {
            return Equals((object?)other); 
        }
        public virtual string GetLocalizedPropertyValue(string propertyName)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var twoLetterCulture = currentCulture.TwoLetterISOLanguageName;

            var culturePropertyName = propertyName + twoLetterCulture;

            return (string)GetType().GetProperty(culturePropertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance)?.GetValue(this, null);
        }

    }

    public class Price : ValueObject
    {
        public decimal Amount { get; private set; }
        public decimal Currancy { get; private set;}
        public Price (decimal amount, decimal currancy)
        {
            Amount = amount;
            Currancy = currancy;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currancy;
        }
        

    }
}
