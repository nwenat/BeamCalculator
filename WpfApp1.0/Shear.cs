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
        // beta cc wspol. nosnosci zalezny od czasu dojrzewania materialu in [-]
        private Double betaCC;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double BetaCC
        {
            get
            {
                return betaCC;
            }
        }

        public Shear(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            //betaCC = 1.0;
            //fCmT = 1.0;
            //fCkT = 1.0;
            //fCtmT = 1.0;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BetaCC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCmT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCkT"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FCtmT"));

            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeltaPel"));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PMo"));
        }
    }
}
