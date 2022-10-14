using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ_001
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int[] mass = Enumerable.Range(1,1000000).ToArray();

            var result = (from m in mass.AsParallel() // Здесь происходит распараллеливание, если это возможно.
                         where m % 3 == 0
                         orderby m descending
                         select m).ToArray();

            Console.WriteLine(result.Count());

            Console.ReadKey();

        }
    }
}
