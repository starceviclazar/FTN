﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Client2;

namespace RTUManager
{
	public class RTUManagerViewModel : ViewModelBase
	{
		private ObservableCollection<RTU> rtus;
		private RTU selectedRTU = null;
		private RelayCommand startCommand;
		private RelayCommand stopCommand;

		public RTUManagerViewModel()
		{
			rtus = new ObservableCollection<RTU>();
		}

		public RelayCommand StartCommand
		{
			get { return startCommand ?? (new RelayCommand(p => StartCommandExecute(), p => CanStartCommandExecute())); }
		}

		public RelayCommand StopCommand
		{
			get { return stopCommand ?? (new RelayCommand(p => StopCommandExecute(), p => CanStopCommandExecute())); }
		}

		public void StartCommandExecute()
		{
			selectedRTU.Start();
		}

		public bool CanStartCommandExecute()
		{
			return selectedRTU != null;
		}

		public void StopCommandExecute()
		{
			selectedRTU.Stop();
		}

		public bool CanStopCommandExecute()
		{
			return selectedRTU != null;
		}
	}
}