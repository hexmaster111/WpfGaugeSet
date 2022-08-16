using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeckenGayGauges
{
    // This class implements INotifyPropertyChanged
    // to support one-way and two-way bindings
    // (such that the UI element updates when the source
    // has been changed dynamically)
    public class RoundGaugeView : INotifyPropertyChanged
    {
        public string _gaugeSubTidle = "Hello mini world";
        private string _gaugeMainTidle = "HELLO WORLD";
        private double _gaugeAngle = 0.0;
        private double _gaugeValue = 0.0;

        private double _minValue = 0.0;
        private double _maxValue = 1.0;
        
        private bool _showGhostNeadle = false;
        private double _ghostNeedleValue = 0.0;
        
        


        public RoundGaugeView()
        {
        }

        public RoundGaugeView(string value, double initalValue)
        {
            _gaugeMainTidle = value;
            _gaugeValue = initalValue;
        }

        
        
        public double GhostNeedleValue
        {
            get { return _ghostNeedleValue; }
            set
            {
                _ghostNeedleValue = value;
                OnPropertyChanged("GhostNeedleValue");
            }
        }
        
        

        public bool ShowGhostNeedle
        {
            get { return _showGhostNeadle; }
            set
            {
                _showGhostNeadle = value;
                OnPropertyChanged("ShowGhostNeedle");
            }
        }
        
        
        
        /// <summary>
        /// Smallest value that can be displayed on the gauge
        /// </summary>
        public double MinimumValue
        {
            get => _minValue;
            set
            {
                _minValue = value;
                OnPropertyChanged("MinimumValue");
            }
        }


        /// <summary>
        /// Largest value that can be displayed on the gauge
        /// </summary>
        public double MaximumValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                OnPropertyChanged("MaximumValue");
            }
        }


        public double GaugeValue
        {
            get => _gaugeValue;
            set
            {
                _gaugeValue = value;
                OnPropertyChanged("GaugeValue");

                // Update the angle of the gauge
                GaugeAngle = ((value - MinimumValue) / (MaximumValue - MinimumValue) * 180) - 90;
            }
        }


        /// <summary>
        /// Value sent to the gauge angle
        /// </summary>
        public double GaugeAngle
        {
            get => _gaugeAngle;
            set
            {
                if (_gaugeAngle != value)
                {
                    _gaugeAngle = value;
                    OnPropertyChanged("GaugeAngle");
                }
            }
        }

        public string GaugeMainTidle
        {
            get => _gaugeMainTidle;
            set
            {
                _gaugeMainTidle = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("GaugeMainTidle");
            }
        }

        public string GaugeSubTidle
        {
            get => _gaugeSubTidle;
            set
            {
                _gaugeSubTidle = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("GaugeSubTidle");
            }
        }


        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}