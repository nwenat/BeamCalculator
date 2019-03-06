using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam
    {
        private static CrossSectionCharacteristics crossSectionCharacteristics = new CrossSectionCharacteristics();
        private static CrossSectionType crossSectionType = new CrossSectionType();
        private static StaticScheme staticScheme = new StaticScheme();
        private static ConcreteParameters concreteParameters = new ConcreteParameters();
        private static CalculateCommand calculateCommand = new CalculateCommand();
        private static CompressionType compressionType = new CompressionType();
        private static DataCrossSectionCommand dataCrossSectionCommand = new DataCrossSectionCommand();

        public CrossSectionCharacteristics CrossSectionCharacteristics
        {
            get { return crossSectionCharacteristics; }
            set { crossSectionCharacteristics = value; }
        }

        public CrossSectionType CrossSectionType
        {
            get { return crossSectionType; }
            set { crossSectionType = value; }
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
