using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
	public class Callback : WcfService.IServiceWithCBCallback
	{
		public void OnCallback(int id, double value, DateTime date, int type)
		{
			throw new NotImplementedException();
		}
	}
}
