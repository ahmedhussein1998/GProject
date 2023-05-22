
using Gproject.Domain.Common.Models;

namespace Gproject.Domain.Common.ValueObjects
{
    public class CellPhone : ValueObject
    {
        public string CountryPrefix { get; private set; }
        public string Number { get; private set; }

        private CellPhone() { }
        public CellPhone(string countryPrefix, string number)
        {
            CountryPrefix = countryPrefix;
            //Number = number ?? throw new NullReferenceException("Mobile Number cant be null");
            Number = number ;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return CountryPrefix;
            yield return Number;
        }
    }
}
