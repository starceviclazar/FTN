using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Client2;
using Model;

namespace RTUManager
{
	public class RTUManagerViewModel : ViewModelBase
	{
		private ObservableCollection<Client2.RTU> rtus;
		private Client2.RTU selectedRTU = null;
		private RelayCommand startCommand;
		private RelayCommand stopCommand;

		public RTUManagerViewModel()
		{
			rtus = new ObservableCollection<Client2.RTU>();
			foreach (Model.RTU rtu in EntityManager.getRTUs())
			{
				rtus.Add(new Client2.RTU(rtu.RTU_ID, rtu.NAME, rtu.RTU_TYPE));
			}
		}

		public RelayCommand StartCommand
		{
			get { return startCommand ?? (new RTUManager.RelayCommand(p => StartCommandExecute(), p => CanStartCommandExecute())); }
		}

		public RelayCommand StopCommand
		{
			get { return stopCommand ?? (new RTUManager.RelayCommand(p => StopCommandExecute(), p => CanStopCommandExecute())); }
		}

		public ObservableCollection<Client2.RTU> Rtus
		{
			get { return rtus; }
			set { rtus = value; }
		}

		public Client2.RTU SelectedRTU
		{
			get { return selectedRTU; }
			set
			{
				selectedRTU = value;
				OnPropertyChanged("SelectedRTU");
			}
		}

		public void StartCommandExecute()
		{
			selectedRTU.Start();
		}

		public bool CanStartCommandExecute()
		{
			return selectedRTU != null && !selectedRTU.isStarter();
		}

		public void StopCommandExecute()
		{
			selectedRTU.Stop();
		}

		public bool CanStopCommandExecute()
		{
			return selectedRTU != null && selectedRTU.isStarter();
		}
	}
}
