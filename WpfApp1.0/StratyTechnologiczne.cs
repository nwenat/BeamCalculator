using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class StratyTechnologiczne : INotifyPropertyChanged
    {
        // LToru in [m]
        private Double lToru;
        // deltaPs1 in [kN]
        private Double deltaPs1;
        private Double p0s1;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double LToru
        {
            get
            {
                return lToru;
            }
        }

        public Double DeltaPs1
        {
            get
            {
                return deltaPs1;
            }
        }

        public Double P0s1
        {
            get
            {
                return p0s1;
            }
        }

        public StratyTechnologiczne(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            lToru = 3* beam.Beam.Dimensions.Length + 4 * 0.2;
            deltaPs1 = beam.Beam.DifferentData.As1 / lToru * beam.Beam.PrestressingSteelParameters.EP * beam.CrossSectionCalculatedCharacteristics.AreaAp * 0.0001;
            p0s1 = beam.MaxForcesInActiveSteel.P0Max - deltaPs1;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LToru"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPs1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("P0s1"));
        }

    }
}
