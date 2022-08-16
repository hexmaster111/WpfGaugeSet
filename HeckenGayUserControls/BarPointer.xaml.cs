using System.Windows.Controls;
using System.Windows.Data;

namespace HeckenGayGauges;

public partial class BarPointer : UserControl
{
    
    public FlatGaugeView GetDataContext()
    {
        var binding = BindingOperations.GetBindingExpression(TbSubLabel, TextBlock.TextProperty);
        var sourceData = (FlatGaugeView)binding.DataItem;
        return sourceData;
    }
    
    public BarPointer()
    {
        InitializeComponent();
    }
}