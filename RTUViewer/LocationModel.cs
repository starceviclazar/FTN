using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTUViewer
{
	public class LocationModel
	{
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public LocationModel(int id)
		{
			this.id = id;
		}
	}
}
