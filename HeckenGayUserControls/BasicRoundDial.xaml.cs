using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;


namespace HeckenGayGauges
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BasicRoundDial : UserControl
    {
       
        public RoundGaugeView GetDataContext()
        {
            var binding = BindingOperations.GetBindingExpression(TbSubLabel, TextBlock.TextProperty);
            var sourceData = (RoundGaugeView)binding.DataItem;
            return sourceData;
        }
        
        
        public BasicRoundDial()
        {
            InitializeComponent();
            this.DataContext = new RoundGaugeView();

            // Thread t = new Thread(() =>
            // {
            //     bool _run = true;
            //     bool _once = false;
            //     
            //     GetDataContext().MinimumValue = 0;
            //     GetDataContext().MaximumValue = 10;
            //     
            //     while (_run)
            //     {
            //         Thread.Sleep(25);
            //         Dispatcher.Invoke(() =>
            //         {
            //             var sourceData = GetDataContext();
            //             if(!_once)
            //                 sourceData.GaugeValue = sourceData.GaugeValue + 0.1;
            //             else
            //                 sourceData.GaugeValue = sourceData.GaugeValue - 0.1;
            //         });
            //         
            //         if(GetDataContext().GaugeValue > 10 || GetDataContext().GaugeValue < 0)
            //         {
            //             if (_once)
            //             {
            //                 _run = false;
            //                 GetDataContext().GaugeValue = 0;
            //             }
            //             _once = true;
            //         }
            //     }
            // });
            //
            // t.Start();
            
        }
    }
}