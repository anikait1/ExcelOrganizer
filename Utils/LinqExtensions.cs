using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicExcelOrganizer.Utils
{

    public static class LinqExtensions
    {
        public static IEnumerable<TResult> SelectSkipExceptions<TSource, TResult>(
            this IEnumerable<TSource> values,
            Func<TSource, TResult> selector)
        {
            foreach (var item in values)
            {
                TResult output;
                try
                {
                    Console.WriteLine($"Processing {item}");
                    output = selector(item);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Previous file is skipped. Error: {exception.Message}");
                    continue;
                }

                yield return output;
            }
        }
    }
}
