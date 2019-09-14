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

        public event PropertyChangedEventHandler PropertyChanged;

        public StratyTechnologiczne(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            lToru = 3* beam.Beam.Dimensions.Length + 4 * 0.2;
            deltaPs1 = 3 / lToru * beam.Beam.PrestressingSteelParameters.EP * beam.CrossSectionCalculatedCharacteristics.AreaAp * 0.0001;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("?"));
        }

    }
}
