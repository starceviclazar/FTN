using Model;
using RTUViewer.WcfService;
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
		private RelayCommand showReportCommand;
		private RichTextBox console;
		private int selectedReport = 0;
		private DateTime startDate = DateTime.Now.AddDays(-1);
		private DateTime endDate = DateTime.Now;
		private double value;

		private bool isDateEnabled = true;
		private bool isValueEnabled = true;
		private bool isLocationEnabled = true;

		public RTUViewerViewModel(RichTextBox console)
		{
			//SelectedReport = 0;
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

		public RelayCommand ShowReportCommand
		{
			get { return showReportCommand ?? (showReportCommand = new RelayCommand(p => ShowReportCommandExecute(), p => CanShowReportCommandExecute())); }
		}

		public bool IsDateEnabled
		{
			get { return isDateEnabled; }
			set
			{
				isDateEnabled = value;
				OnPropertyChanged("IsDateEnabled");
			}
		}

		public bool IsValueEnabled
		{
			get { return isValueEnabled; }
			set
			{
				isValueEnabled = value;
				OnPropertyChanged("IsValueEnabled");
			}
		}

		public bool IsLocationEnabled
		{
			get { return isLocationEnabled; }
			set
			{
				isLocationEnabled = value;
				OnPropertyChanged("IsLocationEnabled");
			}
		}

		public double Value
		{
			get { return this.value; }
			set
			{
				this.value = value;
				OnPropertyChanged("Value");
			}
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
				Refres();
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

		public void ShowReportCommandExecute()
		{
			ReportClient client = new ReportClient();
			string report = string.Empty;

			switch(SelectedReport)
			{
				case 0: report = client.GetReportAll(startDate, endDate); break;
				case 1: report = client.GetReportRTU(selectedRTU.ID, startDate, endDate); break;
				case 2: report = client.GetReportTime(Value); break;
				case 3: report = client.AverageReport(SelectedLocation, startDate, endDate); break;
				case 4: report = client.GetReportTimeLocation(SelectedLocation, Value); break;
			}

			ReportView view = new ReportView(report);
			view.ShowDialog();
		}

		public bool CanShowReportCommandExecute()
		{
			if(SelectedReport != 1)
			{
				return true;
			}

			return selectedRTU != null;
			
		}

		public void Refres()
		{
			if (SelectedReport == 0 || SelectedReport == 1)
			{
				IsDateEnabled = true;
				IsValueEnabled = false;
				IsLocationEnabled = false;
			}
			else if(SelectedReport == 2)
			{
				IsDateEnabled = false;
				IsValueEnabled = true;
				IsLocationEnabled = false;
			}
			else if (SelectedReport == 3)
			{
				IsDateEnabled = true;
				IsValueEnabled = false;
				IsLocationEnabled = true;
			}
			else if (SelectedReport == 4)
			{
				IsDateEnabled = false;
				IsValueEnabled = true;
				IsLocationEnabled = true;
			}
		}
	}
}
