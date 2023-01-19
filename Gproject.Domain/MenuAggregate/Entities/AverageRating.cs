using Gproject.Domain.Common.Models;
using Gproject.Domain.MenuAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Domain.MenuAggregate.Entities
{
    public sealed class AverageRating
    {
        private AverageRating(string value, string numRating)
        {
            value = value;
            NumRating = numRating;
        }

        public string value { get; private set; }
        public string NumRating { get; private set; }

        public static AverageRating CreateNew()
        {
            return new AverageRating(value, NumRating);
        }
        #pragma warning disable CS8618
        private AverageRating()
        {

        }
        #pragma warning restore CS8618
    }
}
