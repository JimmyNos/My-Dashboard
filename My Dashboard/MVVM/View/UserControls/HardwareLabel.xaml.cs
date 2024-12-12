using System.Windows;
using System.Windows.Controls;

namespace My_Dashboard.MVVM.View.UserControls
{
    public partial class HardwareLabel : UserControl
    {
        public string StatName
        {
            get => (string)GetValue(StatNameProperty);
            set => SetValue(StatNameProperty, value);
        }
        public static readonly DependencyProperty StatNameProperty =
            DependencyProperty.Register(nameof(StatName), typeof(string), typeof(HardwareLabel));

        public int StatGauge
        {
            get => (int)GetValue(StatGaugeProperty);
            set => SetValue(StatGaugeProperty, value);
        }
        public static readonly DependencyProperty StatGaugeProperty =
            DependencyProperty.Register(nameof(StatGauge), typeof(int), typeof(HardwareLabel));

        public int StatValue
        {
            get => (int)GetValue(StatValueProperty);
            set => SetValue(StatValueProperty, value);
        }
        public static readonly DependencyProperty StatValueProperty =
            DependencyProperty.Register(nameof(StatValue), typeof(int), typeof(HardwareLabel));

        public string StatSymbol
        {
            get => (string)GetValue(StatSymbolProperty);
            set => SetValue(StatSymbolProperty, value);
        }
        public static readonly DependencyProperty StatSymbolProperty =
            DependencyProperty.Register(nameof(StatSymbol), typeof(string), typeof(HardwareLabel));

        public HardwareLabel()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
