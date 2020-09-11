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
        // sigma cg in [MPa]
        private Double sigmaCg;
        // sigma cp0 in [MPa]
        private Double sigmaCp0;
        // sigma pi in [MPa]
        private Double sigmaPi;
        // mi in [-]
        private Double mi;
        // delta sigma pr in [MPa]
        private Double deltaSigmaPr;

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

        // alfa ds1 wspol. zalezny od klasy cementu
        private Double alfaDs1;
        // alfa ds2 wspol. zalezny od klasy cementu
        private Double alfaDs2;
        // alfa wspol. zalezny od klasy cementu
        private Double alfa;

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
        // delta t in [dni]
        private Double deltaT;

        
        public event PropertyChangedEventHandler PropertyChanged;

        public Double SigmaCg
        {
            get
            {
                return sigmaCg;
            }
        }

        public Double SigmaCp0
        {
            get
            {
                return sigmaCp0;
            }
        }

        public Double SigmaPi
        {
            get
            {
                return sigmaPi;
            }
        }

        public Double Mi
        {
            get
            {
                return mi;
            }
        }

        public Double DeltaSigmaPr
        {
            get
            {
                return deltaSigmaPr;
            }
        }

        public Double BetaAsT
        {
            get
            {
                return betaAsT;
            }
        }

        public Double EpsilonCa8
        {
            get
            {
                return epsilonCa8;
            }
        }

        public Double EpsilonCaT
        {
            get
            {
                return epsilonCaT;
            }
        }

        public Double Kh
        {
            get
            {
                return kh;
            }
        }

        public Double BetaDsTTs
        {
            get
            {
                return betaDsTTs;
            }
        }

        public Double EpsilonCd0
        {
            get
            {
                return epsilonCd0;
            }
        }

        public Double EpsilonCdT
        {
            get
            {
                return epsilonCdT;
            }
        }

        public Double EpsilonCs
        {
            get
            {
                return epsilonCs;
            }
        }

        public Double FiRH
        {
            get
            {
                return fiRH;
            }
        }

        public Double T0
        {
            get
            {
                return t0;
            }
        }

        public Double BetaT0
        {
            get
            {
                return betaT0;
            }
        }

        public Double Fi0
        {
            get
            {
                return fi0;
            }
        }

        public Double BetaH
        {
            get
            {
                return betaH;
            }
        }

        public Double BetaC8T0
        {
            get
            {
                return betaC8T0;
            }
        }

        public Double Fi8T0
        {
            get
            {
                return fi8T0;
            }
        }

        public Double DeltaSigmaPCSR
        {
            get
            {
                return deltaSigmaPCSR;
            }
        }

        public Double DeltaPt
        {
            get
            {
                return deltaPt;
            }
        }

        public Double Pmt
        {
            get
            {
                return pmt;
            }
        }

        public DelayedLosses(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            sigmaCg = -1000 * (beam.Forces.MomentGK + beam.Forces.MomentDGK + beam.Forces.MomentPK) * beam.AdHocLosses.Zcp / beam.CrossSectionCalculatedCharacteristics.IXCS;
            sigmaCp0 = ((beam.AdHocLosses.PMo / beam.CrossSectionCalculatedCharacteristics.AreaAcs) + ((beam.AdHocLosses.PMo * Math.Pow(beam.AdHocLosses.Zcp ,2)) / beam.CrossSectionCalculatedCharacteristics.IXCS)) * 10;
            sigmaPi = ((beam.AdHocLosses.PMo / beam.CrossSectionCalculatedCharacteristics.AreaAp) + (((beam.Forces.MomentGK + beam.Forces.MomentDGK + beam.Forces.MomentPK) * 100 * beam.AdHocLosses.Zcp) / beam.CrossSectionCalculatedCharacteristics.IXCS)
                * beam.CrossSectionCalculatedCharacteristics.AlfaP) * 10;
            mi = sigmaPi / beam.Beam.PrestressingSteelParameters.Fpk;
            deltaSigmaPr = 0.66 * sigmaPi * 2.5 * Math.Pow(Math.E, 9.1 * mi) * Math.Pow(500, 0.75 * (1 - mi)) * Math.Pow(10, -5);

            betaAsT = 1 - Math.Pow(Math.E, -0.2*Math.Sqrt(beam.Beam.DifferentData.TOpoznione * 365));
            epsilonCa8 = 2.5 * (beam.Beam.ConcreteParameters.Fck - 10) * Math.Pow(10, -6);
            epsilonCaT = betaAsT * epsilonCa8;
            u = beam.CrossSectionCalculatedCharacteristics.U;
            h0 = (2 * beam.CrossSectionCalculatedCharacteristics.Area) / u;
            kh = 0.7 + Math.Pow(Math.E, -(h0 / 100));

            deltaT = beam.Beam.DifferentData.TOpoznione * 365 - beam.Beam.DifferentData.TsOpoznione;
            betaDsTTs = deltaT / (deltaT + 0.4 * Math.Sqrt(Math.Pow(h0, 2)));

            setAlfaFromKlasaCem(beam.Beam.DifferentData.KlasaCem);
            epsilonCd0 = 1.318 * (220 + 110 * alfaDs1) * (1 - Math.Pow(0.01 * beam.Beam.DifferentData.RH, 3)) * Math.Pow(Math.E, -0.1 * alfaDs2 * beam.Beam.ConcreteParameters.Fcm) * Math.Pow(10, -6);
            epsilonCdT = betaDsTTs * kh * epsilonCd0;
            epsilonCs = epsilonCaT + epsilonCdT;

            alfa1 = Math.Pow(35 / beam.Beam.ConcreteParameters.Fcm, 0.7);
            alfa2 = Math.Pow(35 / beam.Beam.ConcreteParameters.Fcm, 0.2);
            alfa3 = Math.Sqrt(35 / beam.Beam.ConcreteParameters.Fcm);
            fiRH = alfa2 * (1 + alfa1 * (1-0.01 * beam.Beam.DifferentData.RH) / (0.1 * Math.Pow(h0, 0.333)));
            t0 = beam.Beam.DifferentData.TsOpoznione * Math.Pow((9 / (2 + Math.Pow(beam.Beam.DifferentData.TsOpoznione, 1.2))) +1 , alfa);
            betaT0 = 1 / (0.1 + Math.Pow(t0, 0.2));
            fi0 = (16.8 / Math.Sqrt(beam.Beam.ConcreteParameters.Fcm)) * fiRH * betaT0;
            betaH = 1.5 * (1 + Math.Pow(0.012 * beam.Beam.DifferentData.RH, 18)) * h0 + 250 * alfa3;
            betaC8T0 = Math.Pow((beam.Beam.DifferentData.TOpoznione *365 - beam.Beam.DifferentData.TsOpoznione) / (betaH + beam.Beam.DifferentData.TOpoznione * 365 - beam.Beam.DifferentData.TsOpoznione), 0.3);
            fi8T0 = fi0 * betaC8T0;

            deltaSigmaPCSR = (epsilonCs * beam.Beam.PrestressingSteelParameters.EP * 1000 + 0.8 * DeltaSigmaPr + beam.CrossSectionCalculatedCharacteristics.AlfaP * fi8T0 * (sigmaCg + sigmaCp0))
                / (1 + beam.CrossSectionCalculatedCharacteristics.AlfaP * (beam.CrossSectionCalculatedCharacteristics.AreaAp / beam.CrossSectionCalculatedCharacteristics.Area)
                * (1 + (beam.CrossSectionCalculatedCharacteristics.AreaAcs / beam.CrossSectionCalculatedCharacteristics.IXCS) * Math.Pow(beam.AdHocLosses.Zcp , 2))
                * (1 + 0.8 * fi8T0));

            deltaPt = beam.CrossSectionCalculatedCharacteristics.AreaAp * deltaSigmaPCSR * 0.1;
            pmt = beam.AdHocLosses.P0 - beam.AdHocLosses.DeltaPel - deltaPt;


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaCg"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaCp0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaPi"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mi"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaSigmaPr"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaAsT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EpsilonCa8"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EpsilonCaT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Kh"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaDsTTs"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EpsilonCd0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EpsilonCdT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EpsilonCs"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiRH"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("T0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaT0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fi0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaH"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaC8T0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Fi8T0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaSigmaPCSR"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPt"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pmt"));
        }

        private void setAlfaFromKlasaCem(String klasaCem)
        {
            if(klasaCem.Equals("S")) {
                alfaDs1 = 3.0;
                alfaDs2 = 0.13;
                alfa = -1.0;
            }
            else if (klasaCem.Equals("R"))
            {
                alfaDs1 = 6.0;
                alfaDs2 = 0.11;
                alfa = 1.0;
            }
            else if (klasaCem.Equals("N"))
            {
                alfaDs1 = 4.0;
                alfaDs2 = 0.12;
                alfa = 0.0;
            }
            else
            {
                alfaDs1 = 4.0;
                alfaDs2 = 0.12;
                alfa = 0.0;
            }
        }
    }
}
