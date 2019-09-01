using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Dimensions : INotifyPropertyChanged
    {
        // length m
        private Double length = 5.0;
        // dimensiton cm
        private Double dimH = 15.0;
        private Double dimD1 = 14.0;
        private Double dimBD1 = 13.0;
        private Double dimD2 = 12.0;
        private Double dimBD2 = 11.0;
        private Double dimB = 10.0;

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

        public Double DimH        {
            get
            {
                return dimH;
            }
            set
            {
                if (value > 0)
                {
                    dimH = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimH"));
                }
            }
        }

        public Double DimD1
        {
            get
            {
                return dimD1;
            }
            set
            {
                if (value > 0)
                {
                    dimD1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimD1"));
                }
            }
        }

        public Double DimBD1
        {
            get
            {
                return dimBD1;
            }
            set
            {
                if (value > 0)
                {
                    dimBD1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimBD1"));
                }
            }
        }

        public Double DimD2
        {
            get
            {
                return dimD2;
            }
            set
            {
                if (value > 0)
                {
                    dimD2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimD2"));
                }
            }
        }

        public Double DimBD2
        {
            get
            {
                return dimBD2;
            }
            set
            {
                if (value > 0)
                {
                    dimBD2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimBD2"));
                }
            }
        }

        public Double DimB
        {
            get
            {
                return dimB;
            }
            set
            {
                if (value > 0)
                {
                    dimB = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimB"));
                }
            }
        }
       
    }
}
