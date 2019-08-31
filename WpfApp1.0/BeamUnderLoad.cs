using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class BeamUnderLoad
    {
        private Beam beam = new Beam();
        private Forces forces;

        public BeamUnderLoad()
        {
            beam.PropertyChanged += BeamPropertyChangedEventHandler;
            forces = new Forces(this);
        }

        public Beam Beam
        {
            get { return beam; }
        }

        public Forces Forces
        {
            get { return forces; }
        }

        void BeamPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            Calculate();
        }

        void Calculate()
        {
            forces.Calculate(this);
        }
    }
}
