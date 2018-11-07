using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLibrary
{
    public class InvokeBookExample
    {
        public static void Task1()
        {
            Console.WriteLine("T1 start");
            Thread.Sleep(1000);
            Console.WriteLine("T1 end");
        }

        public static void Task2()
        {
            Console.WriteLine("T2 start");
            Thread.Sleep(2000);
            Console.WriteLine("T2 end");
        }

        public InvokeBookExample()
        {
            Parallel.Invoke(Task1, Task2);
            Console.WriteLine("Process End");
        }
    }

    public class InvokeOwnExample
    {
        public void TwoTimes()
        {
            for (int number = 0; number < 100; number++)
            {
                Console.WriteLine(number * 2);
            }
        }

        public void ThreeTimes()
        {
            for (int number = 0; number < 100; number++)
            {
                Console.WriteLine(number * 2);
            }
        }

        public InvokeOwnExample()
        {
            Parallel.Invoke(TwoTimes, ThreeTimes);
            Console.WriteLine("Done");
        }
    }
}
