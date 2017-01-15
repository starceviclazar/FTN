using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace Service
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, InstanceContextMode = InstanceContextMode.Single)]
	public class ServiceWithCB : IServiceWithCB, IMeasure
	{
		private List<Subscriber> subscribers = new List<Subscriber>();
		private Dictionary<string, double> measurements = new Dictionary<string, double>();

		public string Start()
		{
			return "Service started.";
		}

		public void Measure(int rtuId, double value, DateTime time, int type)
		{
			FTNEntities db = new FTNEntities();

			MEASUREMENT m = new MEASUREMENT();
			m.MEASUREMENT_TIME = DateTime.Now;
			m.MEASUREMENT_TYPE = type;
			m.MEASUREMENT_VALUE = value;
			m.RTU_ID = rtuId;

			db.MEASUREMENTs.Add(m);
			db.SaveChanges();
		}

		public void Subscribe(int clientId, int rtuId)
		{
			Subscriber subscriber = null;

			subscriber = subscribers.Find(s => s.ClientId == clientId);

			if(subscribers == null)
			{
				subscriber = new Subscriber(clientId,
					OperationContext.Current.GetCallbackChannel<IServiceWithCBCallback>(),
					new List<int> {rtuId }
					);

				return;
			}

			if(subscriber.Rtus.Contains(rtuId))
			{
				return;
			}

			subscriber.Rtus.Add(rtuId);
		}

		public void Unsubscribe(int clientId, int rtuId)
		{
			Subscriber subscriber = null;

			subscriber = subscribers.Find(s => s.ClientId == clientId);

			if(subscriber == null)
			{
				return;
			}

			subscriber.Rtus.Remove(rtuId);
		}
	}
}
