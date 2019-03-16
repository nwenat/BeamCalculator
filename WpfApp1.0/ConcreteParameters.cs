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
        private String concreteClassDescription = EnumDescribe.GetDescribe(ConcreteClasses.C20);
        private Double gamaC = 1.5;
        // fck and fcd in [MPa]
        private int fck = 20;
        private Double fcd = 0.0;
        // Ecm in [Gpa]
        private Double eCm = 30.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConcreteClasses ConcreteClass
        {
            get
            { return concreteClass; }
            set
            {
                concreteClass = EnumDescribe.GetValueFromDescription<ConcreteClasses>(value.ToString());
                
                UpdateData();
            }
        }

        public Array TypesOfConcrete
        {
            get
            {
                var abc =  Enum.GetValues(typeof(ConcreteClasses));
                List<ConcreteClasses> arr = abc.OfType<ConcreteClasses>().ToList();
                List<String> result = new List<string>();
                foreach (ConcreteClasses cC in arr)
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
                UpdateData();
                switch (concreteClass)
                {
                    case ConcreteClasses.C16:
                        fck = 16;
                        eCm = 29;
                        Calculate();
                        break;
                    case ConcreteClasses.C20:
                        fck = 20;
                        eCm = 30;
                        Calculate();
                        break;
                    case ConcreteClasses.C25:
                        fck = 25;
                        eCm = 31;
                        Calculate();
                        break;
                }
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
            [Description("C16/20")]
            C16,
            [Description("C20/25")]
            C20,
            [Description("C25/30")]
            C25
        }
    }
}
