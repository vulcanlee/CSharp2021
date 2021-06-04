using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzSfGridRefresh.Pages
{
    public class OutputHelper
    {
        public static void Output(string message)
        {
            //var bar = System.Threading.SynchronizationContext.Current == null ? "Has No" : "Has";
            //Console.WriteLine($"This Thread {bar} SynchronizationContext");
            var foo = System.Threading.SynchronizationContext.Current == null ? "No" : "Yes";
            Console.WriteLine($"{message} " +
                $"(Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId}) [SC:{foo}]");
        }
    }
}
