using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParallelLibrary;
using Parallel_Library;

namespace Verification
{
    [TestClass]
    public class InvokeTests
    {
        [TestMethod]
        public void InvokeBookExampleTest()
        {
            var sw = new Stopwatch();
            sw.Start();
            var invoke = new InvokeBookExample();
            sw.Stop();
            Assert.IsTrue(2000 - sw.ElapsedMilliseconds > -5 && 2000 - sw.ElapsedMilliseconds < 5);
        }

        [TestMethod]
        public void InvokeOwnExampleTest()
        {
            var Expectedsw = new Stopwatch();
            Expectedsw.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i * 4);
            }
            Expectedsw.Stop();

            var actualSw = new Stopwatch();
            actualSw.Start();
            var invoke = new InvokeOwnExample();
            actualSw.Stop();

            Console.WriteLine(Expectedsw.ElapsedMilliseconds);
            Console.WriteLine(actualSw.ElapsedMilliseconds);

            Assert.IsTrue(Expectedsw.ElapsedMilliseconds - actualSw.ElapsedMilliseconds > -5 && Expectedsw.ElapsedMilliseconds - actualSw.ElapsedMilliseconds < 5);
        }
    }

    [TestClass]
    public class ForEachTests
    {
        [TestMethod]
        public void ForEachBookExampleTest()
        {
            var parallelSw = new Stopwatch();
            parallelSw.Start();
            new ForEachBookExample();
            parallelSw.Stop();

            var syncProcessSw = new Stopwatch();
            syncProcessSw.Start();
            foreach (var i in Enumerable.Range(0,500))
            {
                Console.WriteLine($"Working on {i} Sync");
                Thread.Sleep(1);
                Console.WriteLine($"Finished on {i} Sync");
            }
            syncProcessSw.Stop();

            Console.WriteLine(syncProcessSw.ElapsedMilliseconds - parallelSw.ElapsedMilliseconds);

            Assert.IsTrue(parallelSw.ElapsedMilliseconds < syncProcessSw.ElapsedMilliseconds);
        }
    }
}
