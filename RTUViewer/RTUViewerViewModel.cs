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
		private RTUModel selectedRTU = null;
		private RelayCommand subscribeCommand;
		private RelayCommand unsubscribeCommand;
		private RichTextBox console;

		public RTUViewerViewModel(RichTextBox console)
		{
			this.console = console;
			rtus = new ObservableCollection<RTUModel>();
			foreach (Model.RTU rtu in EntityManager.getRTUs())
			{
				rtus.Add(new RTUModel(rtu.RTU_ID, rtu.NAME, rtu.RTU_TYPE, console));
			}
		}

		public RelayCommand SubscribeCommand
		{
			get { return subscribeCommand ?? (new RelayCommand(p => SubscribeCommandExecute(), p => CanSubscribeCommandExecute())); }
		}

		public RelayCommand UnsubscribeCommand
		{
			get { return unsubscribeCommand ?? (new RelayCommand(p => UnsubscribeCommandExecute(), p => CanUnsubscribeCommandExecute())); }
		}

		public ObservableCollection<RTUModel> Rtus
		{
			get { return rtus; }
			set { rtus = value; }
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
