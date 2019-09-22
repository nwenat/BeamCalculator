using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Ranges : INotifyPropertyChanged
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

        private Double hz;
        private Double x;
        private Double aAp1;

        private Double nMin;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ranges(BeamUnderLoad beam)
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

        public Double NMin
        {
            get
            {
                return nMin;
            }
        }

        public Double Hz
        {
            get
            {
                return hz;
            }
        }

        public Double X
        {
            get
            {
                return x;
            }
        }

        public Double Ap1
        {
            get
            {
                return aAp1;
            }
        }

        public void Calculate(BeamUnderLoad beam)
        {
            Dimensions d = beam.Beam.Dimensions;

            minDimH = d.Length * 100 / 25;
            maxDimH = d.Length * 100 / 15;

            minDimD1 = 0.12 * d.DimH;
            maxDimD1 = 0.2 * d.DimH;
            minDimBD1 = 0.3 * d.DimH;
            maxDimBD1 = 0.6 * d.DimH;
            minDimD2 = 0.1 * d.DimH;
            maxDimD2 = 0.15 * d.DimH;
            minDimBD2 = 0.4 * d.DimH;
            maxDimBD2 = 0.8 * d.DimH;
            minDimB = 0.1 * d.DimH;
            maxDimB = 0.12 * d.DimH;

            hz = d.DimH - d.E1;
            // Moment in [cm]
            Double M = (beam.Forces.MomentQ + beam.Forces.MomentDG + beam.Forces.MomentG) * 100;
            x = hz - Math.Sqrt(Math.Pow(hz, 2) - 2 * M / ((beam.Beam.ConcreteParameters.Fcd / 10) * d.DimBD2));
            aAp1 = beam.Beam.ConcreteParameters.Fcd / beam.Beam.PrestressingSteelParameters.Fpd * d.DimBD2 * x;

            nMin = aAp1 / (beam.Beam.PrestressingSteelParameters.Ap / 100);

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

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NMin"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hz"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ap1"));
        }
    }
}
