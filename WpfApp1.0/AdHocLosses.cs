using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class AdHocLosses : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;

        public AdHocLosses(BeamUnderLoad beam)
        {
            //Calculate(beam);
        }

    }
}
