using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCharacteristics : INotifyPropertyChanged
    {
        private Double width = 0.0;
        private Double height = 0.0;
        private Double area = 0.0;

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

        public Double Area
        {
            get
            {
                return area;
            }
        }

        public void UpdateData()
        {
            area = width * height;
            PropertyChanged(this, new PropertyChangedEventArgs("Area"));
        }
    }
}
