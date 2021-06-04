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
                OutputHelper.Output($"FilterClass Id has changed {myVar}");
            }
        }

        private string myVarTitle;

        public string Title
        {
            get { return myVarTitle; }
            set
            {
                myVarTitle = value;
                OutputHelper.Output($"FilterClass Title has changed {myVarTitle}");
            }
        }

    }
}
