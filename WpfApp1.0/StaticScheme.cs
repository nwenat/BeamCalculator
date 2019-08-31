using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class StaticScheme : INotifyPropertyChanged
    {
        private Double length = 5.0;
        private Double continuosusLoad = 1.0;
        private Double maxBendingMoment = 0.0;
        private Double maxShearForce = 0.0;

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
                    UpdateData();
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
                UpdateData();
            }
        }

        public Double MaxBendingMoment
        {
            get
            {
                Calculate();
                return maxBendingMoment;
            }
        }

        public Double MaxShearForce
        {
            get
            {
                Calculate();
                return maxShearForce;
            }
        }

        public void Calculate()
        {
            maxBendingMoment = (continuosusLoad * length * length) / 8;
            maxShearForce = 0.5 * continuosusLoad * length;
        }

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("MaxBendingMoment"));
            PropertyChanged(this, new PropertyChangedEventArgs("MaxShearForce"));
        }
    }
}
