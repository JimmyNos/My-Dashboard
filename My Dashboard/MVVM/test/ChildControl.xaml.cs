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

namespace My_Dashboard.MVVM.test
{
    /// <summary>
    /// Interaction logic for ChildControl.xaml
    /// </summary>
    public partial class ChildControl : UserControl
    {
        public static readonly DependencyProperty DisplayTextProperty =
            DependencyProperty.Register("DisplayText", typeof(string), typeof(ChildControl), new PropertyMetadata(string.Empty));

        public string DisplayText
        {
            get => (string)GetValue(DisplayTextProperty);
            set => SetValue(DisplayTextProperty, value);
        }

        public ChildControl()
        {
            InitializeComponent();
            DataContext = this; // Optional if using direct binding in XAML
        }
    }
}
