using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCharacteristics : INotifyPropertyChanged
    {
        private Double width = 0.0;
        private Double height = 0.0;
        private Double areaConcrete = 0.0;
        private int countAs1 = 2;
        private Double fiAsi = 8;
        private Double areaAs1 = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }

        public Double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }

        public int CountAs1
        {
            get
            {
                return countAs1;
            }
            set
            {
                if (value >= 0)
                {
                    countAs1 = value;
                }
            }
        }

        public Double FiAs1
        {
            get
            {
                return fiAsi;
            }
            set
            {
                if (value > 0)
                {
                    fiAsi = value;
                }
            }
        }

        public Double AreaConcrete
        {
            get
            {
                return areaConcrete;
            }
        }

        public Double AreaAs1
        {
            get
            {
                return areaAs1;
            }
        }

        public void UpdateData()
        {
            areaAs1 = 1;
            areaConcrete = width * height - areaAs1;
            PropertyChanged(this, new PropertyChangedEventArgs("AreaConcrete"));
            PropertyChanged(this, new PropertyChangedEventArgs("AreaAs1"));
        }
    }
}
