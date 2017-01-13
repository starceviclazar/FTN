using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Callback:WcfService.IServiceWithCBCallback
    {
        public void OnCallback(string id, double value)
        {
			Console.WriteLine(string.Format("ID: {0} - {1}", id, value));
        }
    }
}
