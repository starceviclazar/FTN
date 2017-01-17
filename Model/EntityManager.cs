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


	}
}
