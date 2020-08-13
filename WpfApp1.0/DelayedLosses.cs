using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class DelayedLosses : INotifyPropertyChanged
    {
        // beta as(t) in [-]
        private Double betaAsT;
        // epsilon cs(8) in [-]
        private Double epsilonCa8;
        // epsilon cs(t) in [-]
        private Double epsilonCaT;
        // obwod elementu narazony na wysychanie in [cm]
        private Double u;
        // miarodajny wimiar elementu in [cm]
        private Double h0;
        // wspolczynnik zalezny od h0 in [-]
        private Double kh;
        // beta ds (t,ts) in [-]
        private Double betaDsTTs;
        // epsilon cd,0 in [-]
        private Double epsilonCd0;
        // epsilon cd(t) in [-]
        private Double epsilonCdT;
        // epsilon cs in [-]
        private Double epsilonCs;
        // alfa1 in [-]
        private Double alfa1;
        // alfa2 in [-]
        private Double alfa2;
        // alfa3 in [-]
        private Double alfa3;
        // fiRH wspol uwzg stopien wysychania elementu in [-]
        private Double fiRH;
        // t0 zmodyfikowany wiek betonu in [dni]
        private Double t0;
        // beta (t0) in [-]
        private Double betaT0;
        // fi0 in [-]
        private Double fi0;
        // beta H in [-]
        private Double betaH;
        // beta c(8,t0) in [-]
        private Double betaC8T0;
        // fi (8,t0) in [-]
        private Double fi8T0;
        // delta sigma p.c+s+r in [MPa]
        private Double deltaSigmaPCSR;
        // delta Pt in [kN]
        private Double deltaPt;
        // Pmt in [kN]
        private Double pmt;


        public event PropertyChangedEventHandler PropertyChanged;

        public Double BetaAsT
        {
            get
            {
                return betaAsT;
            }
        }

        public DelayedLosses(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            //sigmaPi = beam.TechnologicalLosses.P0s1 / beam.CrossSectionCalculatedCharacteristics.AreaAp * 10;
            

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaSigmaPr"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPr"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("P0"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaC"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPel"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PMo"));
        }
    }
}
