using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {  
        public static readonly DependencyProperty RatingValueProperty = DependencyProperty.Register(
            "RateValue",
            typeof(int),
            typeof(Rate),
            new PropertyMetadata(0, new PropertyChangedCallback(RateValueChanged)));

        public Color RatedColor { get; set; }
        public Color NotRatedColor { get; set; }
        public Color MouseOverColor { get; set; }

        public int RateValue
        {
            get
            {
                return (int)GetValue(RatingValueProperty);
            }
            set
            {
                if (value > 0 && value <= 5)
                {
                    SetValue(RatingValueProperty, value);
                }
            }
        }

        public Rate()
        {
            InitializeComponent();

            foreach (var b in StarsGrid.Children)
            {
                ((Button)b).BorderBrush = new SolidColorBrush(RatedColor);
            }
        }

        public static void RateValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Rate parent = sender as Rate;
            int rateValue = (int)e.NewValue;

            UIElementCollection stars = parent.StarsGrid.Children;

            foreach (var b in stars)
            {
                ((Button)b).Background = new SolidColorBrush(parent.NotRatedColor);
            }

            foreach (var b in stars)
            {
                if (stars.IndexOf((Button)b) == rateValue) break;

                ((Button)b).Background = new SolidColorBrush(parent.RatedColor);
            }
        }

        private void StarButtonClickEventHandler(object sender, RoutedEventArgs e)
        {
            Button star = sender as Button;
            RateValue = int.Parse((string)star.Tag);
        }
    }
}
