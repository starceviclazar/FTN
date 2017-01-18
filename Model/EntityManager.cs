using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class EntityManager
	{
		public static List<RTU> getRTUs()
		{
			using(Entities db = new Entities())
			{
				var query = from r in db.RTUs select r;
				return query.ToList();
			}
		}

		public static List<LOCATION> getLocations()
		{
			using (Entities db = new Entities())
			{
				var query = from r in db.LOCATIONs select r;
				return query.ToList();
			}
		}

		public static string GetReportAll(DateTime start, DateTime end)
		{
			string report = string.Empty;
			List<MEASUREMENT> result = new List<MEASUREMENT>();

			using (Entities db = new Entities())
			{
				var query = from r in db.MEASUREMENTs where r.MEASUREMENT_TIME > start && r.MEASUREMENT_TIME < end select r ;
				result = query.ToList();
			}

			return MeasurmentsToReport(result);
		}

		public static string GetReportRTU(int id, DateTime start, DateTime end)
		{
			string report = string.Empty;
			List<MEASUREMENT> result = new List<MEASUREMENT>();

			using (Entities db = new Entities())
			{
				var query = from r in db.MEASUREMENTs where r.MEASUREMENT_TIME > start && r.MEASUREMENT_TIME < end && r.RTU_ID == id select r;
				result = query.ToList();
			}

			return MeasurmentsToReport(result);
		}

		public static string GetReportTime(double value)
		{
			List<MEASUREMENT> resultT = new List<MEASUREMENT>();
			List<MEASUREMENT> resultV = new List<MEASUREMENT>();

			using (Entities db = new Entities())
			{
				var query = from r in db.MEASUREMENTs where r.MEASUREMENT_TYPE == 0 && r.MEASUREMENT_VALUE > value select r;
				resultT = query.ToList();

				query = from r in db.MEASUREMENTs where r.MEASUREMENT_TYPE == 1 && r.MEASUREMENT_VALUE < value select r;
				resultV = query.ToList();
			}

			resultT.AddRange(resultV);

			return MeasurmentsToReport(resultT);
		}

		public static string MeasurmentsToReport(List<MEASUREMENT> result)
		{
			string report = string.Empty;

			foreach(MEASUREMENT m in result)
			{
				report += string.Format("RTU: {0} | TIME: {1} | VALUE {2:0.00} | TYPE: {3}\u2028",
					m.RTU_ID,
					m.MEASUREMENT_TIME,
					m.MEASUREMENT_VALUE,
					(m.MEASUREMENT_TYPE == 0) ? "Temperatura" : "Vlaznost");
			}

			return report;
		}

		public static string GetReportTimeLocation(int id, double value)
		{
			List<RTU> rtus = new List<RTU>();

			List<MEASUREMENT> measurements = new List<MEASUREMENT>();

			using (Entities db = new Entities())
			{
				var query = from r in db.RTUs where r.LOCATION_ID == id select r;
				rtus = query.ToList();

				foreach (RTU rtu in rtus)
				{
					var query1 = from r in db.MEASUREMENTs where r.RTU_ID == rtu.RTU_ID && r.MEASUREMENT_VALUE > value select r;

					measurements.AddRange(query1.ToList());
				}
			}

			return MeasurmentsToReport(measurements);
		}

		public static string AverageReport(int location, DateTime start, DateTime end)
		{
			List<RTU> rtus = new List<RTU>();

			List<MEASUREMENT> measurements = new List<MEASUREMENT>();

			using (Entities db = new Entities())
			{
				var query = from r in db.RTUs where r.LOCATION_ID == location select r;
				rtus = query.ToList();

				foreach(RTU rtu in rtus)
				{
					var query1 = from r in db.MEASUREMENTs where r.RTU_ID == rtu.RTU_ID && r.MEASUREMENT_TIME > start && r.MEASUREMENT_TIME < end select r;

					measurements.AddRange(query1.ToList());
				}
			}

			double sumT = 0;
			double sumV = 0;
			int brT = 0;
			int brV = 0;

			foreach(MEASUREMENT m in measurements)
			{
				if(m.MEASUREMENT_TYPE == 0)
				{
					sumT += m.MEASUREMENT_VALUE;
					brT++;
				}
				else
				{
					sumV += m.MEASUREMENT_VALUE;
					brV++;
				}
			}


			double srT = (brT !=0) ? sumT / brT : 0;
			double srV = (brV != 0) ? sumV / brV : 0;


			return string.Format("Avg temperature: {0:0.00}| Avg vlaznost: {1:0.00}", srT, srV);
		}


	}


}
