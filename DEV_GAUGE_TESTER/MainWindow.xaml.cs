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
        private BarPointer _basicRoundDial = new();

        public MainWindow()
        {
            
            InitializeComponent();
            CcGauge.Content = _basicRoundDial;

            var gauge = _basicRoundDial.GetDataContext();
            
            gauge.MinimumValue = 0;
            gauge.MaximumValue = 1;
            gauge.GaugeMainTidle = "Tidle";
            gauge.GaugeSubTidle = "Sub Tidle";
            gauge.ShowNeedle = true;
            gauge.ShowMajorTicks = true;
            gauge.ShowMinorTicks = true;
            gauge.ShowValueLabel = true;
            gauge.UnitLabel = "SliderUnits";
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _basicRoundDial.GetDataContext().GaugeValue = e.NewValue;
        }
    }
}