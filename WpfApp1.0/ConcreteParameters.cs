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
        private int rhoB = 25;
        // fck and fcd in [MPa]
        private int fck = 40;
        private Double fcm = 48.0;
        private Double fcd;
        private Double fctk = 2.5;
        private Double fctm = 3.5;
        private Double fctd;
        // Ecm in [Gpa]
        private Double eCm = 35.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConcreteParameters()
        {
            Calculate();
        }

        public Double GamaC
        {
            get
            {
                return gamaC;
            }
        }

        public int RhoB
        {
            get
            {
                return rhoB;
            }
            set
            {
                rhoB = value;
                UpdateData();
            }
        }
        public int Fck
        {
            get
            {
                return fck;
            }
        }

        public Double Fcm
        {
            get
            {
                return fcm;
            }
        }

        public Double Fcd
        {
            get
            {
                return fcd;
            }
        }

        public Double Fctk
        {
            get
            {
                return fctk;
            }
        }

        public Double Fctm
        {
            get
            {
                return fctm;
            }
        }

        public Double Fctd
        {
            get
            {
                return fctd;
            }
        }

        public Double ECm
        {
            get
            {
                return eCm;
            }
        }

        public Array GammaBArray
        {
            get
            {
                return new int[] { 24, 25 };
            }
        }
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
                        fcm = 48;
                        fctk = 2.5;
                        fctm = 3.5;
                        eCm = 35;
                        break;
                    case ConcreteClasses.C45:
                        fck = 45;
                        fcm = 53;
                        fctk = 2.7;
                        fctm = 3.8;
                        eCm = 36;
                        break;
                    case ConcreteClasses.C50:
                        fck = 50;
                        fcm = 58;
                        fctk = 2.9;
                        fctm = 4.1;
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
            PropertyChanged(this, new PropertyChangedEventArgs("ConcreteClassDescription"));
            PropertyChanged(this, new PropertyChangedEventArgs("ConcreteClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("GamaC"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fck"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fcm"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fcd"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fctk"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fctm"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fctd"));
            PropertyChanged(this, new PropertyChangedEventArgs("ECm"));
            PropertyChanged(this, new PropertyChangedEventArgs("RhoB"));
        }

        public void Calculate()
        {
            concreteClassDescription = EnumDescribe.GetDescribe(concreteClass);
            fcd = fck / gamaC;
            fctd = fctk / gamaC;
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
