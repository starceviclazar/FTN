using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	[ServiceContract]
	public interface IReport
	{
		[OperationContract]
		string GetReportRTU(int id, DateTime start, DateTime end);

		[OperationContract]
		string GetReportTime(double value);

		[OperationContract]
		string AverageReport(int location);

		[OperationContract]
		string GetReportTimeLocation(double value);
	}
}
