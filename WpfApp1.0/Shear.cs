using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Shear : INotifyPropertyChanged
    {
        // sila scinajaca V Ed in [kN]
        private Double vEd;
        // Sxcx moment statyczny pola ponad osia przechodzaca przez srodek ciezkosci [cm3]
        private Double sXCS;
        // sigma cp naprezenia sciskajace w betonie na poziomie srodka ciezkosci przekroju zespolonego [MPa]
        private Double sigmaCp;
        // nosnosc przekroju niezarysowanego in [kN]
        private Double vRdC;
        // sigma cp naprezenia sciskajace w betonie od sily podluznej i sprezenia [MPa]
        private Double sigmaCp2;
        // alfa c wpolczynnik 
        private Double alfaC;
        // nosnosc krzyzulca betonowego in [kN]
        private Double vRdMax;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double VEd
        {
            get
            {
                return vEd;
            }
        }

        public Double SXCS
        {
            get
            {
                return sXCS;
            }
        }

        public Double sSigmaCp
        {
            get
            {
                return sigmaCp;
            }
        }

        public Double VRdC
        {
            get
            {
                return vRdC;
            }
        }

        public Double SigmaCp2
        {
            get
            {
                return sigmaCp2;
            }
        }

        public Double AlfaC
        {
            get
            {
                return alfaC;
            }
        }

        public Double VRdMax
        {
            get
            {
                return vRdMax;
            }
        }

        public Shear(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            vEd = ((beam.Beam.Loads.DGLoad + beam.Forces.G) * 1.35 + beam.Beam.Loads.QLoad * 1.5) * beam.Beam.Dimensions.Length * 0.5;
            sXCS = beam.CrossSectionCalculatedCharacteristics.SxCS2;
            sigmaCp = (beam.DelayedLosses.Pmt / beam.CrossSectionCalculatedCharacteristics.AreaAcs) * 10;
            vRdC = (beam.CrossSectionCalculatedCharacteristics.IXCS * beam.Beam.Dimensions.DimB / sXCS) * Math.Sqrt(Math.Pow(beam.Beam.ConcreteParameters.Fctd, 2) + (1 * sigmaCp * beam.Beam.ConcreteParameters.Fctd)) / 10;
            sigmaCp2 = Math.Min(10 * beam.DelayedLosses.Pmt / beam.CrossSectionCalculatedCharacteristics.Area, 0.2 * beam.Beam.ConcreteParameters.Fcd);
            alfaC = 0.0;
            if (sigmaCp2 < 0.25 * beam.Beam.ConcreteParameters.Fcd)
            {
                alfaC = 1 + sigmaCp2 / beam.Beam.ConcreteParameters.Fcd;
            }
            // brakuje else!!!!!!!! i brakuje z

            double z = 50.0;
            double v1 = 0.6 * (1 - beam.Beam.ConcreteParameters.Fck / 250);
            
            vRdMax = (alfaC * beam.Beam.Dimensions.DimB * z * v1 * beam.Beam.ConcreteParameters.Fcd) / 20;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VEd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SXCS"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaCp"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VRdC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SigmaCp2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlfaC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VRdMax"));
        }
    }
}
