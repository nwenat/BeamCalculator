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
        private CrossSectionCalculatedCharacteristics crossSectionCalculatedCharacteristics;
        private Forces forces;
        private DimensionsRange dimensionsRange;
        private MaxForcesInActiveSteel maxForcesInActiveSteel;

        public BeamUnderLoad()
        {
            beam.PropertyChanged += BeamPropertyChangedEventHandler;
            crossSectionCalculatedCharacteristics = new CrossSectionCalculatedCharacteristics(this);
            forces = new Forces(this);
            dimensionsRange = new DimensionsRange(this);
            maxForcesInActiveSteel = new MaxForcesInActiveSteel(this);
        }

        public Beam Beam
        {
            get { return beam; }
        }

        public Forces Forces
        {
            get { return forces; }
        }

        public CrossSectionCalculatedCharacteristics CrossSectionCalculatedCharacteristics
        {
            get { return crossSectionCalculatedCharacteristics; }
        }

        public DimensionsRange DimensionsRange
        {
            get { return dimensionsRange; }
        }

        public MaxForcesInActiveSteel MaxForcesInActiveSteel
        {
            get { return maxForcesInActiveSteel; }
        }

        void BeamPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            Calculate();
        }

        void Calculate()
        {
            crossSectionCalculatedCharacteristics.Calculate(this);
            forces.Calculate(this);
            dimensionsRange.Calculate(this);
            maxForcesInActiveSteel.Calculate(this);
        }
    }
}
