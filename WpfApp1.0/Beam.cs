using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam
    {
        private CrossSectionCharacteristics crossSectionCharacteristics = new CrossSectionCharacteristics();
        private CrossSectionType crossSectionType = new CrossSectionType();
        private StaticScheme staticScheme = new StaticScheme();
        private ConcreteParameters concreteParameters = new ConcreteParameters();
        private CalculateCommand calculateCommand = new CalculateCommand();
        private CompressionType compressionType = new CompressionType();

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
    }
}
