using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTUViewer
{
	public class RTUModel : ViewModelBase
	{
		private string name;
		private int id;
		private bool subscribed = false;
		private Callback callback;
		private InstanceContext instance;
		private RichTextBox console;

		/*
		 * 0 - temperatura
		 * 1 - vlaznost
		 */
		private int type;

		public RTUModel(int id, string name, int type, RichTextBox console)
		{
			this.id = id;
			this.name = name;
			this.type = type;
			this.console = console;
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Status
		{
			get
			{
				if(subscribed)
				{
					return "Subscribed";
				}
				else
				{
					return "Unsubscribed";
				}
			}
		}

		public void Subscribe()
		{
			callback = new Callback(console);
			instance = new InstanceContext(callback);
			WcfService.ServiceWithCBClient proxy = new WcfService.ServiceWithCBClient(instance);

			proxy.Subscribe(1, id);

			subscribed = true;

			console.AppendText(string.Format("RTU: {0} subscribed", id));
			console.AppendText("\u2028");
			console.ScrollToEnd();

			OnPropertyChanged("Status");
		}

		public void Unsubscribe()
		{
			WcfService.ServiceWithCBClient proxy = new WcfService.ServiceWithCBClient(instance);

			proxy.Unsubscribe(1, id);
			subscribed = false;

			console.AppendText(string.Format("RTU: {0} unssubscribed", id));
			console.AppendText("\u2028");
			console.ScrollToEnd();

			OnPropertyChanged("Status");
		}

		public bool IsSubscribed()
		{
			return subscribed;
		}
	}
}
