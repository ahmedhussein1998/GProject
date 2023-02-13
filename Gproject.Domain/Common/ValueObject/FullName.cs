
using Gproject.Domain.Common.Models;

namespace Gproject.Domain.Common.ValueObjects
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string secondName, string thirdName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            SecondName = secondName ?? throw new ArgumentNullException(nameof(secondName));
            ThirdName = thirdName ?? throw new ArgumentNullException(nameof(thirdName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public string ThirdName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {SecondName} {ThirdName} {LastName}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return SecondName;
            yield return ThirdName;
            yield return LastName;
        }
    }
}
