using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTUViewer
{
	public class Callback : WcfService.IServiceWithCBCallback
	{
		private RichTextBox console;

		public Callback(RichTextBox console)
		{
			this.console = console;
		}


		public void OnCallback(int id, double value, DateTime date, int type)
		{
			console.AppendText(string.Format("RTU: {0}|TIME: {1}|VALUE: {2:0.00}|TYPE: {3}", id, date, value, type == 0 ? "TEMPERATURA" : "VLAZNOST"));
			console.AppendText("\u2028");
			console.ScrollToEnd();
		}
	}
}
