using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class AdHocLosses : INotifyPropertyChanged
    {

        // sigma pi in [Mpa]
        private Double sigmaPi;
        // mi - wytezenie stali in [-]
        private Double mi;
        // delta sigma pr in [Mpa]
        private Double deltaSigmaPr;
        // delta Pr in [kN] strata siły sprezajacej
        private Double deltaPr;
        // P0 in [kN] sila poczatkowa w chwili przekazania sprezenia na beton
        private Double p0;
        // sigma c in [MPa] naprezenia
        private Double sigmaC;
        // delta Pel in [kN] straty dorazne spowodowane odksztalceniem sprezystym betonu
        private Double deltaPel;
        // Pmo in [kN] sila sprezajaca po uwzg. strat doraznych
        private Double pMo;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double DeltaSigmaPr
        {
            get
            {
                return deltaSigmaPr;
            }
        }

        public Double DeltaPr
        {
            get
            {
                return deltaPr;
            }
        }

        public Double P0
        {
            get
            {
                return p0;
            }
        }

        public Double SigmaC
        {
            get
            {
                return sigmaC;
            }
        }

        public Double DeltaPel
        {
            get
            {
                return deltaPel;
            }
        }

        public Double PMo
        {
            get
            {
                return pMo;
            }
        }

        public AdHocLosses(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            sigmaPi = beam.TechnologicalLosses.P0s1 / beam.CrossSectionCalculatedCharacteristics.AreaAp * 10;

            // ogarnac reszte
            mi = 0.0;
            deltaSigmaPr = 10.0;
            deltaPr = 150.0;
            p0 = 20.0;
            sigmaC = 30.0;
            deltaPel = 40.0;
            pMo = 50.0;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaSigmaPr"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPr"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("P0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPel"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PMo"));
        }

    }
}
