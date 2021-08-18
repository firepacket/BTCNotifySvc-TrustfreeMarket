using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForm
{
    public static class Extensions
    {
        static Random rand = new Random(DateTime.Now.Millisecond);
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> array)
        {
            List<T> list;
            lock (rand)
            {
                list = (from i in array
                        orderby rand.Next()
                        select i).ToList();
            }
            return list.AsEnumerable();
        }
    }
}
