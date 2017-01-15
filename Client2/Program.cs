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

		static void Main(string[] args)
		{
			Start();
		}

		public static void Start()
		{
			id = GetId();
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
