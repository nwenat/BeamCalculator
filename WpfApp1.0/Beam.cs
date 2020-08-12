using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam : INotifyPropertyChanged
    {
        private Loads loads = new Loads();
        private Dimensions dimensions = new Dimensions();
        private ConcreteParameters concreteParameters = new ConcreteParameters();
        private SteelParameters steelParameters = new SteelParameters();
        private PrestressingSteelParameters prestressingSteelParameters = new PrestressingSteelParameters();
        private DifferentData differentData = new DifferentData();

        private MaterialParametersCommand materialParametersCommand = new MaterialParametersCommand();

        public event PropertyChangedEventHandler PropertyChanged;

        public Beam()
        {
            loads.PropertyChanged += InputPropertyChangedEventHandler;
            dimensions.PropertyChanged += InputPropertyChangedEventHandler;
            concreteParameters.PropertyChanged += InputPropertyChangedEventHandler;
            steelParameters.PropertyChanged += InputPropertyChangedEventHandler;
            prestressingSteelParameters.PropertyChanged += InputPropertyChangedEventHandler;
            differentData.PropertyChanged += InputPropertyChangedEventHandler;
        }

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

        public SteelParameters SteelParameters
        {
            get { return steelParameters; }
            set { steelParameters = value; }
        }

        public PrestressingSteelParameters PrestressingSteelParameters
        {
            get { return prestressingSteelParameters; }
            set { prestressingSteelParameters = value; }
        }

        public DifferentData DifferentData
        {
            get { return differentData; }
            set { differentData = value; }
        }

        public ICommand ShowMaterialParameters
        {
            get { return materialParametersCommand; }
        }

        

        void InputPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }
    }
}
