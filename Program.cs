using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CancelParallelLoopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancelParallelLoopTest cancelParallelLoopTest = new CancelParallelLoopTest();
            //cancelParallelLoopTest.CancelParallel();

            AsyncAwaitTest asyncAwaitTest = new AsyncAwaitTest();
            asyncAwaitTest.AsyncTest().GetAwaiter().GetResult();
        }

        
    }
}
