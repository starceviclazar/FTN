using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RTUViewer
{
	/// <summary>
	/// Interaction logic for ReportView.xaml
	/// </summary>
	public partial class ReportView : Window
	{
		private string report;
		public ReportView(string report)
		{
			this.report = report;

			InitializeComponent();

			view.AppendText(report);
			view.ScrollToEnd();
		}
	}
}
