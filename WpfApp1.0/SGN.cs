using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class SGN : INotifyPropertyChanged
    {
        // beta cc wspol. nosnosci zalezny od czasu dojrzewania materialu in [-]
        private Double betaCC;
        // fcm(t) wytrzymalosc srednia po "t" dniach in [MPa]
        private Double fCmT;
        // fcm(t) wytrzymalosc charakterysyczna po "t" dniach in [MPa]
        private Double fCkT;
        // fcm(t) wytrzymalosc srednia na rozciaganie po "t" dniach in [MPa]
        private Double fCtmT;

        // Pk.sup siła Faza 0 in [kN]
        private Double pKSup;
        // sigma c2 Faza 0 in [MPa]
        private Double sig2F0;
        // sigma c1 Faza 0 in [MPa]
        private Double sig1F0;

        // Pk.sup siła Faza 1 in [kN]
        private Double pD1;
        // sigma c2 Faza 1 in [MPa]
        private Double sig2F1;
        // sigma c1 Faza 1 in [MPa]
        private Double sig1F1;

        // Pk.sup siła Faza 2 in [kN]
        private Double pD2;
        // sigma c2 Faza 2 in [MPa]
        private Double sig2F2;
        // sigma c1 Faza 2 in [MPa]
        private Double sig1F2;


        public event PropertyChangedEventHandler PropertyChanged;

        public Double BetaCC
        {
            get
            {
                return betaCC;
            }
        }

        public Double FCmT
        {
            get
            {
                return fCmT;
            }
        }

        public Double FCkT
        {
            get
            {
                return fCkT;
            }
        }

        public Double FCtmT
        {
            get
            {
                return fCtmT;
            }
        }

        public Double PKSup
        {
            get
            {
                return pKSup;
            }
        }

        public Double Sig2F0
        {
            get
            {
                return sig2F0;
            }
        }

        public Double Sig1F0
        {
            get
            {
                return sig1F0;
            }
        }

        public Double PD1
        {
            get
            {
                return pD1;
            }
        }

        public Double Sig2F1
        {
            get
            {
                return sig2F1;
            }
        }

        public Double Sig1F1
        {
            get
            {
                return sig1F1;
            }
        }

        public Double PD2
        {
            get
            {
                return pD2;
            }
        }

        public Double Sig2F2
        {
            get
            {
                return sig2F2;
            }
        }

        public Double Sig1F2
        {
            get
            {
                return sig1F2;
            }
        }

        public SGN(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            betaCC = Math.Pow(Math.E, 0.2 * (1 - Math.Sqrt(28 / beam.Beam.DifferentData.TSGN)));
            fCmT = betaCC * beam.Beam.ConcreteParameters.Fcm;
            fCkT = fCmT - 8;
            fCtmT = betaCC * beam.Beam.ConcreteParameters.Fctm;

            pKSup = 1.0;
            sig2F0 = 2.0;
            sig1F0 = 3.0;
            pD1 = 4.0;
            sig2F1 = 5.0;
            sig1F1 = 6.0;
            pD2 = 7.0;
            sig2F2 = 8.0;
            sig1F2 = 9.0;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaCC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCmT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCkT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCtmT"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PKSup"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig2F0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig1F0"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PD1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig2F1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig1F1"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PD2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig2F2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sig1F2"));
        }
    }
}
