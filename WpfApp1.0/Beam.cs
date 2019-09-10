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
        private MaterialParametersCommand materialParametersCommand = new MaterialParametersCommand();

        public Beam()
        {
            loads.PropertyChanged += InputPropertyChangedEventHandler;
            dimensions.PropertyChanged += InputPropertyChangedEventHandler;
            concreteParameters.PropertyChanged += InputPropertyChangedEventHandler;
            steelParameters.PropertyChanged += InputPropertyChangedEventHandler;
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

        public ICommand ShowMaterialParameters
        {
            get { return materialParametersCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void InputPropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }
    }
}
