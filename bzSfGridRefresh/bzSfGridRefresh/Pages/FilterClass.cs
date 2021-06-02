using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzSfGridRefresh.Pages
{
    public class FilterClass
    {
        private int myVar;

        public int Id
        {
            get { return myVar; }
            set
            {
                myVar = value;
                Console.WriteLine($"FilterClass Id has changed {myVar}" +
                    $"(Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId})");
            }
        }

        private string myVarTitle;

        public string Title
        {
            get { return myVarTitle; }
            set
            {
                myVarTitle = value;
                Console.WriteLine($"FilterClass Title has changed {myVarTitle}" +
                        $"(Thread:{System.Threading.Thread.CurrentThread.ManagedThreadId})");
            }
        }

    }
}
