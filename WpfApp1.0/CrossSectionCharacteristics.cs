using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCharacteristics : INotifyPropertyChanged
    {
        private Double width = 5.0;
        private Double height = 10.0;
        private Double widthEff = 10.0;
        private Double heightF = 5.0;
        private int countAs1 = 2;
        private int countAp = 2;
        // fi in [mm]
        private int fiAs1 = 8;
        private int fiAp = 8;
        // area in [cm2]
        private Double areaConcrete = 0.0;
        private Double areaAs1 = 0.0;
        private Double areaAp = 0.0;

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

        public Double WidthEff
        {
            get
            {
                return widthEff;
            }
            set
            {
                if (value > 0)
                {
                    widthEff = value;
                }
            }
        }

        public Double HeightF
        {
            get
            {
                return heightF;
            }
            set
            {
                if (value > 0)
                {
                    heightF = value;
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

        public int CountAp
        {
            get
            {
                return countAp;
            }
            set
            {
                if (value >= 0)
                {
                    countAp = value;
                }
            }
        }

        public int FiAs1
        {
            get
            {
                return fiAs1;
            }
            set
            {
                if (value > 0)
                {
                    fiAs1 = value;
                }
            }
        }

        public int FiAp
        {
            get
            {
                return fiAp;
            }
            set
            {
                if (value > 0)
                {
                    fiAp = value;
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

        public Double AreaAp
        {
            get
            {
                return areaAp;
            }
        }

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("AreaConcrete"));
            PropertyChanged(this, new PropertyChangedEventArgs("AreaAs1"));
            PropertyChanged(this, new PropertyChangedEventArgs("AreaAp"));
        }

        public void Calculate()
        {
            areaAs1 = Math.PI * 0.25 * fiAs1 * fiAs1 * 0.01 * countAs1;
            areaAp = Math.PI * 0.25 * fiAp * fiAp * 0.01 * countAp;
            areaConcrete = width * height - areaAs1 - areaAp;
        }
    }
}
