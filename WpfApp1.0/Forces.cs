using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Forces : INotifyPropertyChanged
    {
        //g [kN/m]
        private Double g;
        // moment kNm
        // k - charakterystyczne
        // G - ciezar wlasny
        private Double momentGK;
        private Double momentG;
        // DG - obc. stale
        private Double momentDGK;
        private Double momentDG;
        // Q - obc. zmienne
        private Double momentQK;
        private Double momentQ;
        // P - sila skupiona
        private Double momentPK;
        private Double momentP;
        // force kN
        private Double force;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double G
        {
            get
            {
                return g;
            }
        }

        public Double MomentGK
        {
            get
            {
                return momentGK;
            }
        }

        public Double MomentG
        {
            get
            {
                return momentG;
            }
        }

        public Double MomentDGK
        {
            get
            {
                return momentDGK;
            }
        }

        public Double MomentDG
        {
            get
            {
                return momentDG;
            }
        }

        public Double MomentQK
        {
            get
            {
                return momentQK;
            }
        }

        public Double MomentQ
        {
            get
            {
                return momentQ;
            }
        }

        public Double MomentPK
        {
            get
            {
                return momentPK;
            }
        }

        public Double MomentP
        {
            get
            {
                return momentP;
            }
        }

        public Double Force
        {
            get
            {
                return force;
            }
        }

        public Forces(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            double L = beam.Beam.Dimensions.Length;
            g = beam.CrossSectionCalculatedCharacteristics.Area * 0.0001 * beam.Beam.ConcreteParameters.RhoB;

            switch (beam.Beam.Loads.StaticSystem)
            {
                case Loads.StaticSystemTypes.jednoprzeslowa:
                    momentDGK = (beam.Beam.Loads.DGLoad * Math.Pow(L, 2)) / 8;
                    momentGK = (g * Math.Pow(L, 2)) / 8;
                    momentQK = (beam.Beam.Loads.QLoad * Math.Pow(L, 2)) / 8;
                    momentPK = beam.Beam.Loads.SilaP * L / 4;
                    break;
                //case Loads.StaticSystemTypes.przewieszenie:
                //    momentDGK = (beam.Beam.Loads.DGLoad * Math.Pow(L, 2)) / 8;
                //    momentGK = (g * Math.Pow(L, 2)) / 8;
                //    momentQK = (beam.Beam.Loads.QLoad * Math.Pow(L, 2)) / 8;
                //    momentPK = beam.Beam.Loads.SilaP * L / 4;
                //    break;
                case Loads.StaticSystemTypes.jednoZamocowanie:
                    momentDGK = (beam.Beam.Loads.DGLoad * Math.Pow(L, 2)) * 0.0703;
                    momentGK = (g * Math.Pow(L, 2)) * 0.0703;
                    momentQK = (beam.Beam.Loads.QLoad * Math.Pow(L, 2)) * 0.0703;
                    momentPK = beam.Beam.Loads.SilaP * L * 0.156;
                    break;
                case Loads.StaticSystemTypes.dwaZamocowania:
                    momentDGK = (beam.Beam.Loads.DGLoad * Math.Pow(L, 2)) * 0.0417;
                    momentGK = (g * Math.Pow(L, 2)) * 0.0417;
                    momentQK = (beam.Beam.Loads.QLoad * Math.Pow(L, 2)) * 0.0417;
                    momentPK = beam.Beam.Loads.SilaP * L * 0.125;
                    break;
                default:
                    break;
            }

            momentDG = 1.35 * momentDGK;
            momentG = 1.35 * momentGK;
            momentP = 1.35 * momentPK;
            momentQ = 1.5 * MomentQK;

            force = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQ"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentPK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("G"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Force"));
        }
    }
}
