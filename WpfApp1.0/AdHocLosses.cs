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
            mi = sigmaPi / beam.Beam.PrestressingSteelParameters.Fpk;
            deltaSigmaPr = 0.66 * sigmaPi * 2.5 * Math.Pow(Math.E, 9.1 * mi) * Math.Pow( beam.Beam.DifferentData.TDorazne / 1000, 0.75 * (1 - mi)) * Math.Pow(10, -5);
            deltaPr = deltaSigmaPr * beam.CrossSectionCalculatedCharacteristics.AreaAp * 0.1;
            p0 = beam.TechnologicalLosses.P0s1 - deltaPr;
            Double zcp = beam.CrossSectionCalculatedCharacteristics.YCS - (0.5 * beam.Beam.Dimensions.DimD1);
            sigmaC = ((p0 * Math.Pow(zcp, 2) * 10) / beam.CrossSectionCalculatedCharacteristics.IXCS) + (p0 * 10 / beam.CrossSectionCalculatedCharacteristics.AreaAcs);
            deltaPel = (beam.Beam.PrestressingSteelParameters.EP / beam.Beam.ConcreteParameters.ECm) * beam.CrossSectionCalculatedCharacteristics.AreaAp * sigmaC * 0.1;
            pMo = p0 - deltaPel;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaSigmaPr"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPr"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("P0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPel"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PMo"));
        }

    }
}
