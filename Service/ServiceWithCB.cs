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
        private IServiceWithCBCallback callback;
		private Dictionary<string, double> measurements = new Dictionary<string, double>();
        
        public string Start()
        {
            //inicijalizacija
			callback = OperationContext.Current.GetCallbackChannel<IServiceWithCBCallback>();
  
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

			if (callback != null)
			{
				callback.OnCallback("1", value);
			}
		}
	}
}
