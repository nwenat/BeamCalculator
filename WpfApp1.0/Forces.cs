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
        // moment kNm
        private Double momentGK = 0.0;
        private Double momentG = 0.0;
        private Double momentDGK = 0.0;
        private Double momentDG = 0.0;
        private Double momentQK = 0.0;
        private Double momentQ = 0.0;
        // force kN
        private Double force = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

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
            momentDGK = (beam.Beam.Loads.DGLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentDG = (beam.Beam.Loads.DGLoad * 1.2 * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            //momentGK = (Ac * gamac * length * length) / 8;
            //momentGK = (Ac * gamac * length * length) / 8;
            momentQK = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;
            momentQ = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;

            force = (beam.Beam.Loads.QLoad * beam.Beam.Dimensions.Length * beam.Beam.Dimensions.Length) / 8;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDGK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentDG"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQK"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MomentQ"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Force"));
        }



    }
}
