using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam : INotifyPropertyChanged
    {
        //private CrossSectionCalculatedCharacteristics crossSectionCalculatedCharacteristics = new CrossSectionCalculatedCharacteristics();
        //private CrossSectionProperties crossSectionProperties = new CrossSectionProperties();
        private Loads loads = new Loads();
        private Dimensions dimensions = new Dimensions();
        private ConcreteParameters concreteParameters = new ConcreteParameters();
        //private CalculateCommand calculateCommand = new CalculateCommand();
        //private CompressionType compressionType = new CompressionType();
        //private DataCrossSectionCommand dataCrossSectionCommand = new DataCrossSectionCommand();

        public Beam()
        {
            loads.PropertyChanged += InputPropertyChangedEventHandler;
            dimensions.PropertyChanged += InputPropertyChangedEventHandler;
            concreteParameters.PropertyChanged += InputPropertyChangedEventHandler;
        }

        //public CrossSectionCalculatedCharacteristics CrossSectionCalculatedCharacteristics
        //{
        //    get { return crossSectionCalculatedCharacteristics; }
        //    set { crossSectionCalculatedCharacteristics = value; }
        //}

        //public CrossSectionProperties CrossSectionProperties
        //{
        //    get { return crossSectionProperties; }
        //    set { crossSectionProperties = value; }
        //}

        

        public Loads Loads
        {
            get { return loads; }
            set { loads = value; }
        }

        public Dimensions Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        public ConcreteParameters ConcreteParameters
        {
            get { return concreteParameters; }
            set { concreteParameters = value; }
        }

        //public CompressionType CompressionType
        //{
        //    get { return compressionType; }
        //    set { compressionType = value; }
        //}

        //public ICommand CalculateCommand
        //{
        //    get { return calculateCommand; }
        //}

        //public ICommand ShowCrossSectionData
        //{
        //    get { return dataCrossSectionCommand; }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        void InputPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }
    }
}
