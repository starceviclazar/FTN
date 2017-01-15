using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	class Subscriber
	{
		private int clientId;
		private IServiceWithCBCallback callback;
		private List<int> rtus = new List<int>();

		public Subscriber(int clientId, IServiceWithCBCallback callback, List<int> rtus)
		{
			this.callback = callback;
			this.rtus = rtus;
		}

		public IServiceWithCBCallback Callback
		{
			get { return callback; }
			set { callback = value; }
		}

		public List<int> Rtus
		{
			get { return rtus; }
			set { rtus = value; }
		}

		public int ClientId
		{
			get { return clientId; }
			set { clientId = value; }
		}
	}
}
