using Gproject.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.Common.ValueObjects
{
    public class KeyValueLocalized : ValueObject
    {
        public string Code { get; }
        public string DescriptionAr { get; }
        public string DescriptionEn { get; }
        public string Description => GetLocalizedPropertyValue(nameof(Description));

        public static implicit operator string(KeyValueLocalized name) => name.Description;

        private KeyValueLocalized() { }
        public KeyValueLocalized(string code, string descriptionAr, string descriptionEn)
        {
            Code = code;
            DescriptionAr = descriptionAr;
            DescriptionEn = descriptionEn;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
            yield return DescriptionAr;
            yield return DescriptionEn;
        }
    }
}
