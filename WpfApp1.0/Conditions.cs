using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Conditions : INotifyPropertyChanged
    {
        private Boolean testp = true;
        private Boolean testf = false;

        private Boolean pmtPmtmax = false;
        private Boolean ns2f0 = false;
        private Boolean ns1f0 = false;
        private Boolean ns2f1 = false;
        private Boolean ns1f1 = false;
        private Boolean ns2f2 = false;
        private Boolean ns1f2 = false;
        private Boolean vrdcVedd = false;
        private Boolean vrdmaxVedd = false;
        private Boolean vrdsVedd = false;
        private Boolean uLeff = false;
        private Boolean isProstokat = false;
        private Boolean isTeowy = false;
        private Boolean isSkrzynkowy = false;
        private Boolean isTT = false;
        private Boolean isZwykla = false;
        private Boolean isPrzewieszona = false;
        private Boolean is1Utwierdzenie = false;
        private Boolean is2Utwierdzenia = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public Boolean PmtPmtmax
        {
            get
            {
                return pmtPmtmax;
            }
        }

        public Boolean Ns2f0
        {
            get
            {
                return ns2f0;
            }
        }

        public Boolean Ns1f0
        {
            get
            {
                return ns1f0;
            }
        }

        public Boolean Ns2f1
        {
            get
            {
                return ns2f1;
            }
        }

        public Boolean Ns1f1
        {
            get
            {
                return ns1f1;
            }
        }

        public Boolean Ns2f2
        {
            get
            {
                return ns2f2;
            }
        }

        public Boolean Ns1f2
        {
            get
            {
                return ns1f2;
            }
        }

        public Boolean VrdcVedd
        {
            get
            {
                return vrdcVedd;
            }
        }

        public Boolean VrdmaxVedd
        {
            get
            {
                return vrdmaxVedd;
            }
        }

        public Boolean VrdsVedd
        {
            get
            {
                return vrdsVedd;
            }
        }

        public Boolean ULeff
        {
            get
            {
                return uLeff;
            }
        }

        public Boolean TestP
        {
            get
            {
                return testp;
            }
        }

        public Boolean TestF
        {
            get
            {
                return testf;
            }
        }

        public Boolean IsProstokat
        {
            get
            {
                return isProstokat;
            }
        }

        public Boolean IsTeowy
        {
            get
            {
                return isTeowy;
            }
        }

        public Boolean IsSkrzynkowy
        {
            get
            {
                return isSkrzynkowy;
            }
        }

        public Boolean IsTT
        {
            get
            {
                return isTT;
            }
        }

        public Boolean IsZwykla
        {
            get
            {
                return isZwykla;
            }
        }

        public Boolean IsPrzewieszona
        {
            get
            {
                return isPrzewieszona;
            }
        }

        public Boolean Is1Utwierdzenie
        {
            get
            {
                return is1Utwierdzenie;
            }
        }

        public Boolean Is2Utwierdzenia
        {
            get
            {
                return is2Utwierdzenia;
            }
        }

        public Conditions(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            if(beam.MaxForcesInActiveSteel.PMtMax > beam.DelayedLosses.Pmt)
            {
                pmtPmtmax = true;
            }
            else
            {
                pmtPmtmax = false;
            }

            if (beam.SGN.Sig2F0 > -beam.SGN.FCtmT)
            {
                ns2f0 = true;
            }
            else
            {
                ns2f0 = false;
            }

            if (beam.SGN.Sig1F0 <= beam.SGN.Fckt06)
            {
                ns1f0 = true;
            }
            else
            {
                ns1f0 = false;
            }

            if (beam.SGN.Sig2F1 > -beam.SGN.FCtmT)
            {
                ns2f1 = true;
            }
            else
            {
                ns2f1 = false;
            }

            if (beam.SGN.Sig1F1 <= beam.SGN.Fckt06)
            {
                ns1f1 = true;
            }
            else
            {
                ns1f1 = false;
            }

            if (beam.SGN.Sig2F2 <= 0.6 * beam.Beam.ConcreteParameters.Fck)
            {
                ns2f2 = true;
            }
            else
            {
                ns2f2 = false;
            }

            if (beam.SGN.Sig1F2 > -beam.Beam.ConcreteParameters.Fctm)
            {
                ns1f2 = true;
            }
            else
            {
                ns1f2 = false;
            }

            if (beam.Shear.VRdC > beam.Shear.VEdd)
            {
                vrdcVedd = true;
            }
            else
            {
                vrdcVedd = false;
            }

            if (beam.Shear.VRdMax > beam.Shear.VEdd)
            {
                vrdmaxVedd = true;
            }
            else
            {
                vrdmaxVedd = false;
            }

            if (beam.Stirrups.VRds > beam.Shear.VEdd)
            {
                vrdsVedd = true;
            }
            else
            {
                vrdsVedd = false;
            }

            if (beam.SGU.UU < beam.SGU.Condition)
            {
                uLeff = true;
            }
            else
            {
                uLeff = false;
            }

            if (beam.Beam.Dimensions.BeamType == Dimensions.BeamTypes.prostokatny)
            {
                isProstokat = true;
            }
            else
            {
                isProstokat = false;
            }

            if (beam.Beam.Dimensions.BeamType == Dimensions.BeamTypes.skrzynkowy)
            {
                isSkrzynkowy = true;
            }
            else
            {
                isSkrzynkowy = false;
            }

            if (beam.Beam.Dimensions.BeamType == Dimensions.BeamTypes.dwuteowy)
            {
                isTeowy = true;
            }
            else
            {
                isTeowy = false;
            }

            if (beam.Beam.Dimensions.BeamType == Dimensions.BeamTypes.belkatt)
            {
                isTT = true;
            }
            else
            {
                isTT = false;
            }

            if (beam.Beam.Loads.StaticSystem == Loads.StaticSystemTypes.jednoprzeslowa)
            {
                isZwykla = true;
            }
            else
            {
                isZwykla = false;
            }

            //if (beam.Beam.Loads.StaticSystem == Loads.StaticSystemTypes.przewieszenie)
            //{
            //    isPrzewieszona = true;
            //}
            //else
            //{
            //    isPrzewieszona = false;
            //}

            if (beam.Beam.Loads.StaticSystem == Loads.StaticSystemTypes.jednoZamocowanie)
            {
                is1Utwierdzenie = true;
            }
            else
            {
                is1Utwierdzenie = false;
            }

            if (beam.Beam.Loads.StaticSystem == Loads.StaticSystemTypes.dwaZamocowania)
            {
                is2Utwierdzenia = true;
            }
            else
            {
                is2Utwierdzenia = false;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestF"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PmtPmtmax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns2f0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns1f0"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns2f1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns1f1"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns2f2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ns1f2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VrdcVedd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VrdmaxVedd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VrdsVedd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ULeff"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsProstokat"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsTeowy"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSkrzynkowy"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsTT"));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsZwykla"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsPrzewieszona"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Is1Utwierdzenie"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Is2Utwierdzenia"));
        }
    }
}
