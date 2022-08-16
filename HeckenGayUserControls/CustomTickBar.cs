using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace HeckenGayGauges;

public class CustomTickBar : TickBar
{

    
    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        double num = this.Maximum - this.Minimum;
        double y = this.ReservedSpace * 0.5;
        FormattedText formattedText = null;
        double x = 0;
        for(double i = 0; i <= num; i += this.TickFrequency)
        {


            formattedText = new(i.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface("Verdana"), 8, new SolidColorBrush(Color.FromRgb(0xff, 0x66, 0xff)));

            if(this.Minimum == i)
                x = 0;
            else
                x += this.ActualWidth / (num / this.TickFrequency) ;
            dc.DrawText(formattedText, new Point(x, 10)); 
        }
    }
}