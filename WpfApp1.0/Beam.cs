using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam
    {
        private CrossSectionCharacteristics crossSectionCharacteristics = new CrossSectionCharacteristics();
        private StaticScheme staticScheme = new StaticScheme();
        private CalculateCommand calculateCommand = new CalculateCommand();

        public CrossSectionCharacteristics CrossSectionCharacteristics
        {
            get { return crossSectionCharacteristics; }
            set { crossSectionCharacteristics = value; }
        }

        public StaticScheme StaticScheme
        {
            get { return staticScheme; }
            set { staticScheme = value; }
        }

        public ICommand CalculateCommand
        {
            get { return calculateCommand; }
        }
    }
}
