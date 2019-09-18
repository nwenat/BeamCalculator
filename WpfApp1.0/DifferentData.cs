using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class DifferentData : INotifyPropertyChanged
    {
        // straty technologiczne - maksymalny poslizg ciegien
        private Double as1 = 3.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double As1
        {
            get
            {
                return as1;
            }
            set
            {
                if (value > 0)
                {
                    as1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("As1"));
                }
            }
        }
    }
}
