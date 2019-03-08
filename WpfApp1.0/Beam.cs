﻿using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam
    {
        private CrossSectionCalculatedCharacteristics crossSectionCalculatedCharacteristics = new CrossSectionCalculatedCharacteristics();
        private CrossSectionProperties crossSectionProperties = new CrossSectionProperties();
        private StaticScheme staticScheme = new StaticScheme();
        private ConcreteParameters concreteParameters = new ConcreteParameters();
        private CalculateCommand calculateCommand = new CalculateCommand();
        private CompressionType compressionType = new CompressionType();
        private DataCrossSectionCommand dataCrossSectionCommand = new DataCrossSectionCommand();

        public CrossSectionCalculatedCharacteristics CrossSectionCalculatedCharacteristics
        {
            get { return crossSectionCalculatedCharacteristics; }
            set { crossSectionCalculatedCharacteristics = value; }
        }

        public CrossSectionProperties CrossSectionProperties
        {
            get { return crossSectionProperties; }
            set { crossSectionProperties = value; }
        }

        public StaticScheme StaticScheme
        {
            get { return staticScheme; }
            set { staticScheme = value; }
        }

        public ConcreteParameters ConcreteParameters
        {
            get { return concreteParameters; }
            set { concreteParameters = value; }
        }

        public CompressionType CompressionType
        {
            get { return compressionType; }
            set { compressionType = value; }
        }

        public ICommand CalculateCommand
        {
            get { return calculateCommand; }
        }

        public ICommand ShowCrossSectionData
        {
            get { return dataCrossSectionCommand; }
        }
    }
}
