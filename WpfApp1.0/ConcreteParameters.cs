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
        private ConcreteClasses concreteClass = ConcreteClasses.C40;
        private String concreteClassDescription = EnumDescribe.GetDescribe(ConcreteClasses.C40);
        private Double gamaC = 1.5;
        // gamaB kN/m3
        private int gamaB = 24;
        // fck and fcd in [MPa]
        private int fck = 40;
        private Double fcd = 0.0;
        // Ecm in [Gpa]
        private Double eCm = 35.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Array TypesOfConcrete
        {
            get
            {
                List<ConcreteClasses> list = Enum.GetValues(typeof(ConcreteClasses)).OfType<ConcreteClasses>().ToList();
                List<String> result = new List<String>();
                foreach (ConcreteClasses cC in list)
                {
                    var descript = EnumDescribe.GetDescribe(cC);
                    result.Add(descript);
                }
                return result.ToArray();
            }
        }

        public String ConcreteClassDescription
        {
            set
            {
                concreteClassDescription = value;
                concreteClass = EnumDescribe.GetValueFromDescription<ConcreteClasses>(concreteClassDescription);
                switch (concreteClass)
                {
                    case ConcreteClasses.C40:
                        fck = 40;
                        eCm = 35;
                        break;
                    case ConcreteClasses.C45:
                        fck = 45;
                        eCm = 36;
                        break;
                    case ConcreteClasses.C50:
                        fck = 50;
                        eCm = 37;
                        break;
                }
                UpdateData();
            }
            get
            {
                return concreteClassDescription;
            }
        }

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("ConcreteClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("ConcreteClassDescription"));
        }

        public void Calculate()
        {
            concreteClassDescription = EnumDescribe.GetDescribe(concreteClass);
            fcd = fck / gamaC;
        }

        public enum ConcreteClasses
        {
            [Description("C40/50")]
            C40,
            [Description("C45/55")]
            C45,
            [Description("C50/60")]
            C50
        }
    }
}
