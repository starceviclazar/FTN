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
		private ObservableCollection<Measurement.RTU> rtus;
		private Measurement.RTU selectedRTU = null;
		private RelayCommand startCommand;
		private RelayCommand stopCommand;

		public RTUManagerViewModel()
		{
			rtus = new ObservableCollection<Measurement.RTU>();
			foreach (Model.RTU rtu in EntityManager.getRTUs())
			{
				rtus.Add(new Measurement.RTU(rtu.RTU_ID, rtu.NAME, rtu.RTU_TYPE));
			}
		}

		public RelayCommand StartCommand
		{
			get { return startCommand ?? (startCommand = new RTUManager.RelayCommand(p => StartCommandExecute(), p => CanStartCommandExecute())); }
		}

		public RelayCommand StopCommand
		{
			get { return stopCommand ?? (stopCommand = new RTUManager.RelayCommand(p => StopCommandExecute(), p => CanStopCommandExecute())); }
		}

		public ObservableCollection<Measurement.RTU> Rtus
		{
			get { return rtus; }
			set { rtus = value; }
		}

		public Measurement.RTU SelectedRTU
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
			return selectedRTU != null && !selectedRTU.IsStarter();
		}

		public void StopCommandExecute()
		{
			selectedRTU.Stop();
		}

		public bool CanStopCommandExecute()
		{
			return selectedRTU != null && selectedRTU.IsStarter();
		}
	}
}
