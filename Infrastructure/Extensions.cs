using System.Collections.Generic;
using System.Linq;

namespace Transport.ly.Infrastructure
{
    public static class Extensions
    {
        public static void Write<T>(this IEnumerable<T> list)
        {
            if (list != null && list.Any())
            {
                System.Console.WriteLine($"======= Print List ==== Count: {list.Count()} ======");

                foreach (var item in list)
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine("-------------------------------------------------------");
                }

                System.Console.WriteLine("===========================================================");
            }
            else
            {
                System.Console.WriteLine("List is EMPTY!");
            }
        }
    }
}