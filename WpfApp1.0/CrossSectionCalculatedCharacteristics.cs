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

    }
}
