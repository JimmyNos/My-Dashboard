using Microsoft.Expression.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace My_Dashboard.MVVM.View.UserControls
{
    public partial class HardwareLabel : UserControl
    {
        // Dependency Properties
        public string StatName
        {
            get => (string)GetValue(StatNameProperty);
            set => SetValue(StatNameProperty, value);
        }
        public static readonly DependencyProperty StatNameProperty =
            DependencyProperty.Register(nameof(StatName), typeof(string), typeof(HardwareLabel), new PropertyMetadata("Name"));

        public int StatGauge
        {
            get => (int)GetValue(StatGaugeProperty);
            set => SetValue(StatGaugeProperty, value);
        }
        public static readonly DependencyProperty StatGaugeProperty =
            DependencyProperty.Register(
                nameof(StatGauge),
                typeof(int),
                typeof(HardwareLabel),
                new PropertyMetadata(0, OnStatGaugeChanged));

        public int StatValue
        {
            get => (int)GetValue(StatValueProperty);
            set => SetValue(StatValueProperty, value);
        }
        public static readonly DependencyProperty StatValueProperty =
            DependencyProperty.Register(nameof(StatValue), typeof(int), typeof(HardwareLabel), new PropertyMetadata(24));

        public string StatSymbol
        {
            get => (string)GetValue(StatSymbolProperty);
            set => SetValue(StatSymbolProperty, value);
        }
        public static readonly DependencyProperty StatSymbolProperty =
            DependencyProperty.Register(nameof(StatSymbol), typeof(string), typeof(HardwareLabel), new PropertyMetadata("%"));

        private Storyboard myStoryboard;
        private DoubleAnimation animation;

        public HardwareLabel()
        {
            InitializeComponent();

            // Set up the storyboard and animation for the EndAngle property
            animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(animation);

            // Bind the animation to the EndAngle property
            Storyboard.SetTarget(animation, ArcStatGauge); // Ensure ArcStatGauge exists
            Storyboard.SetTargetProperty(animation, new PropertyPath("EndAngle"));
        }

        // Callback for StatGauge property change
        private static void OnStatGaugeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is HardwareLabel hardwareLabel)
            {
                hardwareLabel.UpdateEndAngle((int)e.NewValue);
            }
        }

        // Update the EndAngle animation dynamically
        private void UpdateEndAngle(int newValue)
        {
            // Stop the previous storyboard
            myStoryboard.Stop();

            // Set the new target value for the animation
            animation.To = newValue;

            // Restart the storyboard
            myStoryboard.Begin();
        }
    }
}
