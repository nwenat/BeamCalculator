﻿using System;
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
        private Ranges ranges;
        private MaxForcesInActiveSteel maxForcesInActiveSteel;
        private CrossSectionCalculatedCharacteristics crossSectionCalculatedCharacteristics;
        private TechnologicalLosses technologicalLosses;
        private AdHocLosses adHocLosses;
        private DelayedLosses delayedLosses;
        private SGU sgu;

        public BeamUnderLoad()
        {
            beam.PropertyChanged += BeamPropertyChangedEventHandler;
            crossSectionCalculatedCharacteristics = new CrossSectionCalculatedCharacteristics(this);
            forces = new Forces(this);
            maxForcesInActiveSteel = new MaxForcesInActiveSteel(this);
            ranges = new Ranges(this);
            technologicalLosses = new TechnologicalLosses(this);
            adHocLosses = new AdHocLosses(this);
            delayedLosses = new DelayedLosses(this);
            sgu = new SGU(this);
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

        public Ranges Ranges
        {
            get { return ranges; }
        }

        public MaxForcesInActiveSteel MaxForcesInActiveSteel
        {
            get { return maxForcesInActiveSteel; }
        }

        public TechnologicalLosses TechnologicalLosses
        {
            get { return technologicalLosses; }
        }

        public AdHocLosses AdHocLosses
        {
            get { return adHocLosses; }
        }

        public DelayedLosses DelayedLosses
        {
            get { return delayedLosses; }
        }

        public SGU SGU
        {
            get { return sgu; }
        }

        void BeamPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            Calculate();
        }

        void Calculate()
        {
            crossSectionCalculatedCharacteristics.Calculate(this);
            forces.Calculate(this);
            maxForcesInActiveSteel.Calculate(this);
            ranges.Calculate(this);
            technologicalLosses.Calculate(this);
            adHocLosses.Calculate(this);
            delayedLosses.Calculate(this);
            sgu.Calculate(this);
        }
    }
}
