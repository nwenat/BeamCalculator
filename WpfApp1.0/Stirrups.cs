using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Stirrups : INotifyPropertyChanged
    {
        // dlugosc odcinka aw [cm]
        private Double aw;
        // pole przekroju zbrejenia na scinanie Asw [cm2]
        private Double asw;
        // max rozstaw strzemon Swmax [cm]
        private Double swMax;
        // nosnosc V Rd,s in [kN]
        private Double vRds;
        // max rozstaw strzemon Sl,max [cm]
        private Double slMax;
        // max rozstaw strzemon Sl,max [cm]
        private Double roWmin;
        // max rozstaw strzemon Sl,max2 [cm]
        private Double slMax2;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double Aw
        {
            get
            {
                return aw;
            }
        }

        public Double Asw
        {
            get
            {
                return asw;
            }
        }

        public Double SwMax
        {
            get
            {
                return swMax;
            }
        }

        public Double VRds
        {
            get
            {
                return vRds;
            }
        }

        public Double SlMax
        {
            get
            {
                return slMax;
            }
        }

        public Double RoWmin
        {
            get
            {
                return roWmin;
            }
        }

        public Double SlMax2
        {
            get
            {
                return slMax2;
            }
        }

        public Stirrups(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            aw = (beam.Shear.VEd - beam.Shear.VRdC) *100 / beam.Shear.Q;
            asw = beam.Beam.DifferentData.M * Math.Pow(beam.Beam.SteelParameters.FiS / 10, 2) * Math.PI / 4.0;
            swMax = (asw / beam.Shear.VEdd) * beam.Shear.Z * beam.Beam.SteelParameters.Fyd / 10;
            vRds = (asw / beam.Beam.DifferentData.Swa) * beam.Shear.Z * beam.Beam.SteelParameters.Fyd / 10;
            slMax = 0.75 * (beam.Beam.Dimensions.DimH - beam.Beam.Dimensions.E1);
            roWmin = 0.08 * (Math.Sqrt(beam.Beam.ConcreteParameters.Fck) / beam.Beam.SteelParameters.Fyk) * 100;
            slMax2 = asw * 100 / (roWmin * beam.Beam.Dimensions.DimB);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Aw"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Asw"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SwMax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VRds"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SlMax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RoWmin"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SlMax2"));
        }
    }
}
