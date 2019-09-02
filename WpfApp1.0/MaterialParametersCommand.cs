using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1._0
{
    class MaterialParametersCommand : ICommand
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
            MaterialParametersView crossSectionData = new MaterialParametersView() { DataContext = parameter };
            crossSectionData.ShowDialog();
        }
    }
}
