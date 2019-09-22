using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class MaxForcesInActiveSteel : INotifyPropertyChanged
    {
        private Double p0Max;
        private Double pM0Max;
        private Double pMtMax;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double P0Max
        {
            get
            {
                return p0Max;
            }
        }

        public Double PM0Max
        {
            get
            {
                return pM0Max;
            }
        }

        public Double PMtMax
        {
            get
            {
                return pMtMax;
            }
        }

        public MaxForcesInActiveSteel(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            PrestressingSteelParameters p = beam.Beam.PrestressingSteelParameters;
            CrossSectionCalculatedCharacteristics ch = beam.CrossSectionCalculatedCharacteristics;

            p0Max = Math.Min(0.8 * p.Fpk * ch.AreaAp,  0.9 * p.Fp01k * ch.AreaAp) / 10;

            pM0Max = Math.Min(0.75 * p.Fpk * ch.AreaAp, 0.85 * p.Fp01k * ch.AreaAp) / 10;

            pMtMax = 0.65 * p.Fpk * ch.AreaAp / 10;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("P0Max"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PM0Max"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PMtMax"));
        }

    }
}
