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
            g = beam.CrossSectionCalculatedCharacteristics.Area * 0.0001 * beam.Beam.ConcreteParameters.RhoB;
            momentDGK = (beam.Beam.Loads.DGLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentDG = (beam.Beam.Loads.DGLoad * 1.35 * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentGK = (g * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentG = (g * 1.35 * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentQK = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentQ = (beam.Beam.Loads.QLoad * 1.5 * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;

            force = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQ"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("G"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Force"));
        }
    }
}
