using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCalculatedCharacteristics : INotifyPropertyChanged
    {
        
        private int countAs1 = 2;
        private int countAp = 2;
        // area in [cm2]
        private Double areaConcrete = 0.0;
        private Double areaAs1 = 0.0;
        private Double areaAp = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        

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

        public void UpdateData(CrossSectionProperties crossSectionProperties)
        {
            Calculate(crossSectionProperties);
            PropertyChanged(this, new PropertyChangedEventArgs("AreaConcrete"));
            PropertyChanged(this, new PropertyChangedEventArgs("AreaAs1"));
            PropertyChanged(this, new PropertyChangedEventArgs("AreaAp"));
        }

        public void Calculate(CrossSectionProperties properties)
        {
            areaAs1 = Math.PI * 0.25 * properties.FiAs1 * properties.FiAs1 * 0.01 * countAs1;
            areaAp = Math.PI * 0.25 * properties.FiAp * properties.FiAp * 0.01 * countAp;
            if (properties.IsTeowy)
            {
                areaConcrete = properties.Width * properties.Height + properties.WidthEff * properties.HeightF - areaAs1 - areaAp;
            } else
            {
                areaConcrete = properties.Width * properties.Height - areaAs1 - areaAp;
            }

        }
    }
}
