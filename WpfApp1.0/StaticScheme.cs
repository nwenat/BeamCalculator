using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class StaticScheme : INotifyPropertyChanged
    {
        // length m
        private Double length = 5.0;
        // load kN/m
        private Double dGLoad = 1.0;
        private Double qLoad = 1.0;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public Double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value > 0)
                {
                    length = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Length"));
                }
            }
        }

        public Double DGLoad
        {
            get
            {
                return dGLoad;
            }
            set
            {
                dGLoad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DGLoad"));
            }
        }

        public Double QLoad
        {
            get
            {
                return qLoad;
            }
            set
            {
                qLoad = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QLoad"));
            }
        }
    }
}
