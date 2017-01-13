using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var callback = new Callback();
            var instance = new InstanceContext(callback);
            WcfService.ServiceWithCBClient proxy = new WcfService.ServiceWithCBClient(instance);

			var callback1 = new Callback();
			var instance1 = new InstanceContext(callback1);
			WcfService.ServiceWithCBClient proxy1 = new WcfService.ServiceWithCBClient(instance1);

            Console.WriteLine( "Server response: {0}", proxy.Start());
			Console.WriteLine("Server response: {0}", proxy1.Start());
            Console.WriteLine("Press any key to stop client...");
            Console.ReadKey();

       

        }
    }
}
