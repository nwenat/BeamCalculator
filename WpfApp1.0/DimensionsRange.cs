using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class DimensionsRange : INotifyPropertyChanged
    {
        private Double minDimH;
        private Double minDimD1;
        private Double minDimBD1;
        private Double minDimD2;
        private Double minDimBD2;
        private Double minDimB;

        private Double maxDimH;
        private Double maxDimD1;
        private Double maxDimBD1;
        private Double maxDimD2;
        private Double maxDimBD2;
        private Double maxDimB;

        public event PropertyChangedEventHandler PropertyChanged;

        public DimensionsRange(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public Double MinDimH
        {
            get
            {
                return minDimH;
            }
        }

        public Double MinDimD1
        {
            get
            {
                return minDimD1;
            }
        }

        public Double MinDimBD1
        {
            get
            {
                return minDimBD1;
            }
        }

        public Double MinDimD2
        {
            get
            {
                return minDimD2;
            }
        }

        public Double MinDimBD2
        {
            get
            {
                return minDimBD2;
            }
        }

        public Double MinDimB
        {
            get
            {
                return minDimB;
            }
        }


        public Double MaxDimH
        {
            get
            {
                return maxDimH;
            }
        }

        public Double MaxDimD1
        {
            get
            {
                return maxDimD1;
            }
        }

        public Double MaxDimBD1
        {
            get
            {
                return maxDimBD1;
            }
        }

        public Double MaxDimD2
        {
            get
            {
                return maxDimD2;
            }
        }

        public Double MaxDimBD2
        {
            get
            {
                return maxDimBD2;
            }
        }

        public Double MaxDimB
        {
            get
            {
                return maxDimB;
            }
        }

        public void Calculate(BeamUnderLoad beam)
        {
            minDimH = beam.Beam.Dimensions.Length * 100 / 25;
            maxDimH = beam.Beam.Dimensions.Length * 100 / 15;

            minDimD1 = 0.12 * beam.Beam.Dimensions.DimH;
            maxDimD1 = 0.2 * beam.Beam.Dimensions.DimH;
            minDimBD1 = 0.3 * beam.Beam.Dimensions.DimH;
            maxDimBD1 = 0.6 * beam.Beam.Dimensions.DimH;
            minDimD2 = 0.1 * beam.Beam.Dimensions.DimH;
            maxDimD2 = 0.15 * beam.Beam.Dimensions.DimH;
            minDimBD2 = 0.4 * beam.Beam.Dimensions.DimH;
            maxDimBD2 = 0.8 * beam.Beam.Dimensions.DimH;
            minDimB = 0.1 * beam.Beam.Dimensions.DimH;
            maxDimB = 0.12 * beam.Beam.Dimensions.DimH;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimH"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimH"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimD1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimD1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimBD1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimBD1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimD2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimD2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimBD2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimBD2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinDimB"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxDimB"));
        }
    }
}
