using My_Dashboard.MVVM.ViewModel.Computer;
using System.Windows.Controls;

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
            DataContext = new ComputerDashboardViewModel(); // Ensure this is set correctly
        }
    }

}
