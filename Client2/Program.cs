using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client2
{
	class Program
	{
		private static string id = string.Empty;
		private static Random radnom = new Random();
		private static readonly object syncLock = new object();

		static void Main(string[] args)
		{
			Start();
		}

		public static void Start()
		{
			id = GetId();

			while (true)
			{
				double value;

				lock (syncLock)
				{
					value = radnom.Next(0, 1000) * radnom.NextDouble();
				}

				Client2.WcfService.MeasureClient client = new Client2.WcfService.MeasureClient();

				client.Measure(1, value, DateTime.Now, 1);

				Thread.Sleep(1000);
			}
		}

		public static string GetId()
		{
			int i, j, k;

			lock (syncLock)
			{
				i = radnom.Next(0, 9);
				j = radnom.Next(0, 9);
				k = radnom.Next(0, 9);
			}

			return string.Format("WZ-{0}{1}{2}", i, j, k);
		}
	}
}
