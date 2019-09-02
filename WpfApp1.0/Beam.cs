using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1._0
{
    class Beam : INotifyPropertyChanged
    {
        private Loads loads = new Loads();
        private Dimensions dimensions = new Dimensions();
        private ConcreteParameters concreteParameters = new ConcreteParameters();
        private MaterialParametersCommand materialParametersCommand = new MaterialParametersCommand();

        public Beam()
        {
            loads.PropertyChanged += InputPropertyChangedEventHandler;
            dimensions.PropertyChanged += InputPropertyChangedEventHandler;
            concreteParameters.PropertyChanged += InputPropertyChangedEventHandler;
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
