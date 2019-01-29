using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class StaticScheme : INotifyPropertyChanged
    {
        private Double length = 5.0;
        private Double continuosusLoad = 1.0;
        private Double maxBendingMoment = 0.0;

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
                }
            }
        }

        public Double ContinuosusLoad
        {
            get
            {
                return continuosusLoad;
            }
            set
            {
                continuosusLoad = value;
            }
        }

        public Double MaxBendingMoment
        {
            get
            {
                return maxBendingMoment;
            }
        }

        public void UpdateData()
        {
            maxBendingMoment = (continuosusLoad * length * length) / 8;
            PropertyChanged(this, new PropertyChangedEventArgs("MaxBendingMoment"));
        }
    }
}
