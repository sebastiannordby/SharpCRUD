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

        public static int SelectRequestedNumberOrLowestAvailable(this IEnumerable<int> values, int requestedNumber)
        {
            if (requestedNumber < 1)
                requestedNumber = 1;

            if (values.Any())
            {
                if (!values.Contains(requestedNumber))
                {
                    return requestedNumber;
                }
                else
                {
                    return values.SelectLowestNumberAvailable();
                }
            }

            return requestedNumber;
        }

        public static int SelectLowestNumberAvailable(this IEnumerable<int> values)
        {
            if (values.Count() > 0)
            {
                var sortedList = new HashSet<int>(values).OrderBy(x => x);

                for (var i = 0; i < sortedList.Count(); i++)
                {
                    var current = sortedList.ElementAt(i);

                    if (!sortedList.Contains(current + 1))
                    {
                        return current + 1;
                    }
                }

                return sortedList.Last() + 1;
            }

            return 1;
        }
    }
}
