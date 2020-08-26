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

        public event PropertyChangedEventHandler PropertyChanged;

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

        public Conditions(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            //q = beam.Beam.Loads.DGLoad + beam.Beam.Loads.QLoad + beam.Forces.G;

            //eCeff = beam.Beam.ConcreteParameters.ECm * 1000 / (1 + beam.DelayedLosses.Fi8T0); // zle
            //u = (5 * (q / 100) * Math.Pow(beam.Beam.Dimensions.Length * 100, 4)) / (384 * (eCeff / 10) * beam.CrossSectionCalculatedCharacteristics.IXCS);
            //s = (-1.0 / 8.0) * (beam.DelayedLosses.Pmt * beam.AdHocLosses.Zcp * Math.Pow(beam.Beam.Dimensions.Length * 100, 2) / ((eCeff / 10) * beam.CrossSectionCalculatedCharacteristics.IXCS));
            //uU = u + s;
            //condition = beam.Beam.Dimensions.Length * 100 / 250;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TestF"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("U"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UU"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Condition"));
        }
    }
}
