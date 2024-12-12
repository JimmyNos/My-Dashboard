using My_Dashboard.MVVM.ViewModel.Computer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_Dashboard.MVVM.View.Computer
{
    /// <summary>
    /// Interaction logic for ComputerDashboardView.xaml
    /// </summary>
    public partial class ComputerDashboardView : UserControl
    {
        public ComputerDashboardView()
        {
            InitializeComponent();
            this.DataContext = new ComputerDashboardViewModel();
        }
    }
}
