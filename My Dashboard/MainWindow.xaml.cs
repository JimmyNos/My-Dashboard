using My_Dashboard.MVVM.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isComp = false;
        public bool isLap = false;
        public bool isNas = false;

        public bool testVar = true;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        //private void btnMaximize_Click(object sender, RoutedEventArgs e)
        //{
        //    if (WindowState == WindowState.Maximized)
        //        WindowState = WindowState.Normal;
        //    else
        //        WindowState = WindowState.Maximized;
        //}

        private void BtnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //Close();
            Application.Current.Shutdown();
        }

        private void RdbtnNas_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void RecDrag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public bool IsBtnComputer()
        {
            //MainWindow mainWindow = new MainWindow();
            if (RdbtnComputer.IsChecked == true)
                return true;
            else return false;
        }
        public bool IsBtnLaptop()
        {
            //MainWindow mainWindow = new MainWindow();
            if (RdbtnLaptop.IsChecked == true)
                return true;
            else return false;
        }
        public bool IsBtnNas()
        {
            //MainWindow mainWindow = new MainWindow();
            if (RdbtnNas.IsChecked == true)
                return true;
            else return false;
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnGraphs_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RdbtnComputer_Click(object sender, RoutedEventArgs e)
        {
            BtnDashboard.IsChecked = true;
        }

        private void RdbtnLaptop_Click(object sender, RoutedEventArgs e)
        {
            BtnDashboard.IsChecked = true;
        }

        private void RdbtnNas_Click(object sender, RoutedEventArgs e)
        {
            BtnDashboard.IsChecked = true;
        }
    }
}