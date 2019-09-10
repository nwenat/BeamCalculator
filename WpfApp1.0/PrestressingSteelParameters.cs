using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class PrestressingSteelParameters : INotifyPropertyChanged
    {
        private PrestressingSteelClasses prestressingSteelClass = PrestressingSteelClasses.a;
        private String prestressingSteelClassDescription = EnumDescribe.GetDescribe(PrestressingSteelClasses.a);
        private PrestressingTypes prestressingType = PrestressingTypes.p7;
        private String prestressingTypeDescription = EnumDescribe.GetDescribe(PrestressingTypes.p7);
        private Double gamaSP = 1.25;
        // fck and fyd in [MPa]
        private int fyk = 500;
        private Double fyd = 434.78;
        // Es in [Gpa]
        private Double eP = 195.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double GamaSP
        {
            get
            {
                return gamaSP;
            }
        }

        public Double Fyk
        {
            get
            {
                return fyk;
            }
        }

        public Double Fyd
        {
            get
            {
                return fyd;
            }
        }

        public Double EP
        {
            get
            {
                return eP;
            }
        }

        public String PrestressingSteelClassDescription
        {
            set
            {
                prestressingSteelClassDescription = value;
                prestressingSteelClass = EnumDescribe.GetValueFromDescription<PrestressingSteelClasses>(prestressingSteelClassDescription);
                switch (prestressingSteelClass)
                {
                    case PrestressingSteelClasses.a:
                        break;
                    case PrestressingSteelClasses.b:
                        break;
                    case PrestressingSteelClasses.c:
                        break;
                }
                UpdateData();
            }
            get
            {
                return prestressingSteelClassDescription;
            }
        }

        public String PrestressingTypeDescription
        {
            set
            {
                prestressingTypeDescription = value;
                prestressingType = EnumDescribe.GetValueFromDescription<PrestressingTypes>(prestressingTypeDescription);
                switch (prestressingType)
                {
                    case PrestressingTypes.p25:
                        break;
                    case PrestressingTypes.p5:
                        break;
                    case PrestressingTypes.p7:
                        break;
                    case PrestressingTypes.s1925:
                        break;
                    case PrestressingTypes.s225:
                        break;
                    case PrestressingTypes.s725:
                        break;
                    case PrestressingTypes.s75:
                        break;
                }
                UpdateData();
            }
            get
            {
                return prestressingTypeDescription;
            }
        }

        public Array TypesOfSteel
        {
            get
            {
                List<PrestressingSteelClasses> list = Enum.GetValues(typeof(PrestressingSteelClasses)).OfType<PrestressingSteelClasses>().ToList();
                List<String> result = new List<String>();
                foreach (PrestressingSteelClasses pSC in list)
                {
                    var descript = EnumDescribe.GetDescribe(pSC);
                    result.Add(descript);
                }
                return result.ToArray();
            }
        }

        public Array TypesOfPrestressing
        {
            get
            {
                List<PrestressingTypes> list = Enum.GetValues(typeof(PrestressingTypes)).OfType<PrestressingTypes>().ToList();
                List<String> result = new List<String>();
                foreach (PrestressingTypes pT in list)
                {
                    var descript = EnumDescribe.GetDescribe(pT);
                    result.Add(descript);
                }
                return result.ToArray();
            }
        }

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("PrestressingSteelClassDescription"));
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("GamaSP"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fck"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fcm"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fi"));
            PropertyChanged(this, new PropertyChangedEventArgs("FiS"));
        }

        public void Calculate()
        {
            fyd = fyk / gamaSP;
        }

        public enum PrestressingSteelClasses
        {
            [Description("cos 1")]
            a,
            [Description("cos 2")]
            b,
            [Description("cos 3")]
            c
        }

        public enum PrestressingTypes
        {
            [Description("\u03C6 2,5mm")]
            p25,
            [Description("\u03C6 5mm")]
            p5,
            [Description("\u03C6 7mm")]
            p7,
            [Description("2x \u03C6 2,5mm")]
            s225,
            [Description("7x \u03C6 2,5mm")]
            s725,
            [Description("19x \u03C6 2,5mm")]
            s1925,
            [Description("7x \u03C6 5mm")]
            s75
        }
    }
}
