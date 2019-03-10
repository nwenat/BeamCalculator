using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class ConcreteParameters : INotifyPropertyChanged
    {
        private ConcreteClasses concreteClass = ConcreteClasses.C20;
        private Double gamaF = 1.4;
        // fck i fcd in [MPa]
        private int fck = 20;
        private Double fcd = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConcreteClasses ConcreteClass
        {
            get
            { return concreteClass; }
            set
            { concreteClass = value; }
        }

        

        public void UpdateData()
        {
            fcd = fck / gamaF;
        }

        public enum ConcreteClasses
        { C16,
          C20,
          C25
        }
    }
}
