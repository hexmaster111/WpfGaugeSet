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
    public class FlatGaugeView : INotifyPropertyChanged
    {
        private string _gaugeSubTidle = "Sub Tidle";
        private string _gaugeMainTidle = "Main Tidle";
        private string _gaugeDisplayValue = "---";
        
        private double _gaugeTranslate = 0.0;
        private double _ghostNeadleTranslate = 0.0;

        private double _gaugeValue = 0.0;
        private double _ghostNeedleValue = 0.0;
        
        
        private double _minValue = 0.0;
        private double _maxValue = 1.0;

        private double _boarderThickenss = 3.2;

        private bool _showGhostNeadle = false;

        
        
        
        public double BoarderThickness
        {
            get => _boarderThickenss;
            set
            {
                _boarderThickenss = value;
                OnPropertyChanged("BoarderThickness");
            }
        }

        
        private double _NumaricalTickFrequency = 0.1;
        
        public double NumaricalTickFrequency
        {
            get => _NumaricalTickFrequency;
            set
            {
                _NumaricalTickFrequency = value;
                OnPropertyChanged("NumaricalTickFrequency");
            }
        }

        private string _unitLabel = "Units";

        public string UnitLabel
        {
            get => _unitLabel;
            set
            {
                _unitLabel = value;
                OnPropertyChanged("UnitLabel");
            }
        }


        private int _displayDesmals = 1;

        public int DisplayDesmals
        {
            get => _displayDesmals;
            set
            {
                _displayDesmals = value;
                OnPropertyChanged("DisplayDesmals");
            }
        }


        private double _MajorTicks = 10;

        public double MajorTicks
        {
            get => _MajorTicks;
            set
            {
                _MajorTicks = value;
                OnPropertyChanged("MajorTicks");
            }
        }


        private double _MinorTicks = 5;

        public double MinorTicks
        {
            get => _MinorTicks;
            set
            {
                _MinorTicks = value;
                OnPropertyChanged("MinorTicks");
            }
        }

        private bool _ShowMajorTicks = true;
        
        public bool ShowMajorTicks
        {
            get => _ShowMajorTicks;
            set
            {
                _ShowMajorTicks = value;
                OnPropertyChanged("ShowMajorTicks");
            }
        }
        
        private bool _ShowMinorTicks = true;
        
        public bool ShowMinorTicks
        {
            get { return _ShowMinorTicks; }
            set
            {
                _ShowMinorTicks = value;
                OnPropertyChanged("ShowMinorTicks");
            }
        }
        
        
        private bool _ShowUnitLabel = true;
        
        public bool ShowUnitLabel
        {
            get { return _ShowUnitLabel; }
            set
            {
                _ShowUnitLabel = value;
                OnPropertyChanged("ShowUnitLabel");
            }
        }
        
        
        
        private bool _ShowValueLabel = true;
        
        public bool ShowValueLabel
        {
            get { return _ShowValueLabel; }
            set
            {
                _ShowValueLabel = value;
                OnPropertyChanged("ShowValueLabel");
            }
        }
        
        
        
        private bool _ShowValue = true;
        
        public bool ShowValue
        {
            get { return _ShowValue; }
            set
            {
                _ShowValue = value;
                OnPropertyChanged("ShowValue");
            }
        }
        
        
        
        private bool _ShowNeedle = true;
        
        public bool ShowNeedle
        {
            get { return _ShowNeedle; }
            set
            {
                _ShowNeedle = value;
                OnPropertyChanged("ShowNeedle");
            }
        }

        


        public FlatGaugeView(string value, double initalValue)
        {
            _gaugeMainTidle = value;
            _gaugeValue = initalValue;
        }

        public FlatGaugeView()
        {
        }


        public double GhostNeedleValue
        {
            get => _ghostNeedleValue;
            set
            {
                _ghostNeedleValue = value;
                OnPropertyChanged("GhostNeedleValue");
            }
        }

        public double GhostNeadleTranslate
        {
            get => _ghostNeadleTranslate;
            set
            {
                _ghostNeadleTranslate = value;
                OnPropertyChanged("GhostNeadleTranslate");
            }
        }


        public bool ShowGhostNeedle
        {
            get => _showGhostNeadle;
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
            get => Math.Round(_minValue, _displayDesmals);
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

                GaugeDisplayValue = Math.Round(_gaugeValue, _displayDesmals) + " " + _unitLabel;

                // Update the Value of the gauge
                GaugeTranslate = _gaugeValue * (600 - 10 - 4) / (_maxValue - _minValue);
            }
        }

        public double GhostNeadleValue
        {
            get => _ghostNeedleValue;
            set
            {
                _ghostNeedleValue = value;
                OnPropertyChanged("GhostNeadleValue");
                GhostNeadleTranslate = _ghostNeedleValue * (600 - 10 - 4) / (_maxValue - _minValue);
            }
        }


        public string GaugeDisplayValue
        {
            get => _gaugeDisplayValue;
            private set
            {
                _gaugeDisplayValue = value;
                OnPropertyChanged("GaugeDisplayValue");

                // Update the Value of the gauge
                GaugeTranslate = _gaugeValue;
            }
        }


        /// <summary>
        /// Bar position value in draw units
        /// </summary>
        public double GaugeTranslate
        {
            get => _gaugeTranslate;
            private set
            {
                if (_gaugeTranslate == value) return;
                _gaugeTranslate = value;
                OnPropertyChanged("GaugeTranslate");
            }
        }

        public string GaugeMainTidle
        {
            get => _gaugeMainTidle;
            set
            {
                _gaugeMainTidle = value;
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