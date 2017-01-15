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
	public class ServiceWithCB : IServiceWithCB, IMeasure, IReport
	{
		private List<Subscriber> subscribers = new List<Subscriber>();
		private Dictionary<string, double> measurements = new Dictionary<string, double>();

		public string Start()
		{
			return "Service started.";
		}

		public void Measure(int rtuId, double value, DateTime time, int type)
		{
			Entities db = new Entities();

			MEASUREMENT m = new MEASUREMENT();
			m.MEASUREMENT_TIME = DateTime.Now;
			m.MEASUREMENT_TYPE = type;
			m.MEASUREMENT_VALUE = value;
			m.RTU_ID = rtuId;

			db.MEASUREMENTs.Add(m);
			db.SaveChanges();

			NotifyClients(m);
		}

		private void NotifyClients(MEASUREMENT measurement)
		{
			foreach(Subscriber subscriber in subscribers)
			{
				if(subscriber.Rtus.Contains(measurement.RTU_ID))
				{
					subscriber.Callback.OnCallback(measurement.RTU_ID, measurement.MEASUREMENT_VALUE, measurement.MEASUREMENT_TIME, measurement.MEASUREMENT_TYPE);
				}
			}
		}

		public void Subscribe(int clientId, int rtuId)
		{
			Subscriber subscriber = null;

			subscriber = subscribers.Find(s => s.ClientId == clientId);

			if(subscriber == null)
			{
				subscriber = new Subscriber(clientId,
					OperationContext.Current.GetCallbackChannel<IServiceWithCBCallback>(),
					new List<int> {rtuId }
					);

				subscribers.Add(subscriber);

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

		public string GetReportRTU(int id, DateTime start, DateTime end)
		{
			throw new NotImplementedException();
		}

		public string GetReportTime(double value)
		{
			throw new NotImplementedException();
		}

		public string AverageReport(int location)
		{
			throw new NotImplementedException();
		}

		public string GetReportTimeLocation(double value)
		{
			throw new NotImplementedException();
		}
	}
}
