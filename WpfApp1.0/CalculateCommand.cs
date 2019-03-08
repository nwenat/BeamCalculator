using System;
using System.Windows.Input;

namespace WpfApp1._0
{
    class CalculateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool executable = true;

        public bool Executable
        {
            get
            {
                return executable;
            }
            set
            {
                executable = value;
                CanExecuteChanged(this, null);
            }
        }

        public bool CanExecute(object parameter)
        {
            return Executable;
        }

        public void Execute(object parameter)
        {
            Beam beam = parameter as Beam;
            CrossSectionCalculatedCharacteristics crossSectionCalcuatedCharacteristics = beam.CrossSectionCalculatedCharacteristics;
            if (crossSectionCalcuatedCharacteristics != null)
            {
                crossSectionCalcuatedCharacteristics.UpdateData(beam);
            }
            StaticScheme staticScheme = beam.StaticScheme;
            if (staticScheme != null)
            {
                staticScheme.UpdateData();
            }
            ConcreteParameters concreteParameters = beam.ConcreteParameters;
            if (concreteParameters != null)
            {
                concreteParameters.UpdateData();
            }
            CrossSectionProperties crossSectionProperties = beam.CrossSectionProperties;
            if (crossSectionProperties != null)
            {
                crossSectionProperties.UpdateData();
            }
        }
    }
}
