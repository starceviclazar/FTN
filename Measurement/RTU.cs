using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Measurement
{
	public class RTU
	{
		private static Random radnom = new Random();
		private static readonly object syncLock = new object();
		private string name;
		private int id;
		private bool collect = false;
		/*
		 * 0 - temperatura
		 * 1 - vlaznost
		 */
		private int type;

		public RTU(int id, string name, int type)
		{
			this.id = id;
			this.name = name;
			this.type = type;
			var t = Task.Run(() => Do());
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public void Do()
		{
			while (true)
			{
				if (!collect)
				{
					continue;
				}

				double value;

				lock (syncLock)
				{
					if(type == 0)
					{
						value = radnom.Next(-50, 50) * radnom.NextDouble();
					}
					else
					{
						value = radnom.Next(50, 80) * radnom.NextDouble();
					}
				}

				Client2.WcfService.MeasureClient client = new Client2.WcfService.MeasureClient();

				client.Measure(id, value, DateTime.Now, type);

				if(type == 0)
				{
					Thread.Sleep(1000);
				}
				else
				{
					Thread.Sleep(6000);
				}
			}
		}

		public void Start()
		{
			collect = true;
		}

		public void Stop()
		{
			collect = false;
		}

		public bool IsStarter()
		{
			return collect;
		}
	}
}
