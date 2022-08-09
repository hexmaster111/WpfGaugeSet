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
using HeckenGayGauges;

namespace DEV_GAUGE_TESTER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BasicRoundDial _basicRoundDial = new();

        public MainWindow()
        {
            InitializeComponent();
            CcGauge.Content = _basicRoundDial;

            _basicRoundDial.GetDataContext().MinimumValue = 0;
            _basicRoundDial.GetDataContext().MaximumValue = 10;
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // _basicRoundDial.SetValue(e.NewValue);
            _basicRoundDial.GetDataContext().GaugeValue = e.NewValue;
        }
    }
}