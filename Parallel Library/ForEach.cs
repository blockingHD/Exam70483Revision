using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_Library
{
    public class ForEachBookExample
    {
        public void SomeTask(int item)
        {
            Console.WriteLine($"Working on {item}");
            Thread.Sleep(1);
            Console.WriteLine($"Finished on {item}");
        }

        public ForEachBookExample()
        {
            var items = Enumerable.Range(0, 500);
            Parallel.ForEach(items, SomeTask);
        }
    }
}
