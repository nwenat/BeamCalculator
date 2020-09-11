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
        private Double hz;
        private Double x;
        private Double aAp1;

        private Double nMin;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ranges(BeamUnderLoad beam)
        {
            Calculate(beam);
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
            hz = beam.CrossSectionCalculatedCharacteristics.Hz;
            // Moment in [kNcm]
            Double M = (beam.Forces.MomentQ + beam.Forces.MomentDG + beam.Forces.MomentG + beam.Forces.MomentP) * 100;
            x = hz - Math.Sqrt(Math.Pow(hz, 2) - 2 * M / ((beam.Beam.ConcreteParameters.Fcd / 10) * beam.CrossSectionCalculatedCharacteristics.BNmin));
            aAp1 = beam.Beam.ConcreteParameters.Fcd / beam.Beam.PrestressingSteelParameters.Fpd * beam.CrossSectionCalculatedCharacteristics.BNmin * x;

            nMin = aAp1 / (beam.Beam.PrestressingSteelParameters.Ap / 100);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NMin"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hz"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("X"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ap1"));
        }
    }
}
