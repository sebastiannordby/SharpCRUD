using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.Domain.Extensions
{
    internal static class NumberSeriesExtensions
    {
        internal static int NewNumberOrOne(this IEnumerable<int> numbers)
        {
            if(numbers.Any())
            {
                return numbers.Max() + 1;
            } 

            return 1;
        }
    }
}
