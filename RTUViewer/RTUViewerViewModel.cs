using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTUViewer
{
	public class RTUViewerViewModel : ViewModelBase
	{
		private ObservableCollection<RTUModel> rtus;
		private ObservableCollection<int> locations;
		private RTUModel selectedRTU = null;
		private int selectedLocation = 1;
		private RelayCommand subscribeCommand;
		private RelayCommand unsubscribeCommand;
		private RichTextBox console;
		private int selectedReport = 0;
		private DateTime startDate = DateTime.Now.AddDays(-1);
		private DateTime endDate = DateTime.Now;

		public RTUViewerViewModel(RichTextBox console)
		{
			this.console = console;
			rtus = new ObservableCollection<RTUModel>();
			locations = new ObservableCollection<int>();
			foreach (Model.RTU rtu in EntityManager.getRTUs())
			{
				rtus.Add(new RTUModel(rtu.RTU_ID, rtu.NAME, rtu.RTU_TYPE, console));
			}

			foreach (Model.LOCATION location in EntityManager.getLocations())
			{
				locations.Add(location.LOCATION_ID);
			}
		}

		public RelayCommand SubscribeCommand
		{
			get { return subscribeCommand ?? (subscribeCommand = new RelayCommand(p => SubscribeCommandExecute(), p => CanSubscribeCommandExecute())); }
		}

		public RelayCommand UnsubscribeCommand
		{
			get { return unsubscribeCommand ?? (unsubscribeCommand = new RelayCommand(p => UnsubscribeCommandExecute(), p => CanUnsubscribeCommandExecute())); }
		}

		public DateTime StartDate
		{
			get { return startDate; }
			set
			{
				startDate = value;
				OnPropertyChanged("StartDate");
			}
		}

		public DateTime EndDate
		{
			get { return endDate; }
			set
			{
				endDate = value;
				OnPropertyChanged("EndDate");
			}
		}

		public ObservableCollection<RTUModel> Rtus
		{
			get { return rtus; }
			set { rtus = value; }
		}

		public ObservableCollection<int> Locations
		{
			get { return locations; }
			set { locations = value; }
		}

		public int SelectedReport
		{
			get { return selectedReport; }
			set
			{
				selectedReport = value;
				OnPropertyChanged("SelectedReport");
			}
		}

		public int SelectedLocation
		{
			get { return selectedLocation; }
			set
			{
				selectedLocation = value;
				OnPropertyChanged("SelectedLocation");
			}
		}

		public RTUModel SelectedRTU
		{
			get { return selectedRTU; }
			set
			{
				selectedRTU = value;
				OnPropertyChanged("SelectedRTU");
			}
		}

		public void SubscribeCommandExecute()
		{
			selectedRTU.Subscribe();
		}

		public bool CanSubscribeCommandExecute()
		{
			return selectedRTU != null && !selectedRTU.IsSubscribed();
		}

		public void UnsubscribeCommandExecute()
		{
			selectedRTU.Unsubscribe();
		}

		public bool CanUnsubscribeCommandExecute()
		{
			return selectedRTU != null && selectedRTU.IsSubscribed();
		}
	}
}
