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
        private PrestressingSteelClasses prestressingSteelClass = PrestressingSteelClasses.y1860s7;
        private String prestressingSteelClassDescription = EnumDescribe.GetDescribe(PrestressingSteelClasses.y1860s7);
        private PrestressingTypes prestressingType = PrestressingTypes.pp25;
        private String prestressingTypeDescription = EnumDescribe.GetDescribe(PrestressingTypes.pp25);
        private Double gamaSP = 1.25;
        // fck and fpk in [MPa]
        private Double fpk;
        private Double fpd;
        private Double fp01k;
        // forces Fpk, Fpd in [kN]
        private Double forcePk = 173.0;
        private Double forcePd;
        // Es in [Gpa]
        private Double eP = 195.0;
        // ap in [mm2] (pole 1 ciegna)
        private Double ap = 93.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public PrestressingSteelParameters()
        {
            Calculate();
        }

        public Double GamaSP
        {
            get
            {
                return gamaSP;
            }
        }

        public Double Fpk
        {
            get
            {
                return fpk;
            }
        }

        public Double Fpd
        {
            get
            {
                return fpd;
            }
        }

        public Double Fp01k
        {
            get
            {
                return fp01k;
            }
        }

        public Double EP
        {
            get
            {
                return eP;
            }
        }

        public Double ForcePk
        {
            get
            {
                return forcePk;
            }
        }

        public Double ForcePd
        {
            get
            {
                return forcePd;
            }
        }

        public Double Ap
        {
            get
            {
                return ap;
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
                    case PrestressingSteelClasses.y1860s7:
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
            PropertyChanged(this, new PropertyChangedEventArgs("PrestressingTypeDescription"));
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("GamaSP"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fpk"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fpd"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fp01k"));
        }

        public void Calculate()
        {
            forcePd = 0.9 * forcePk / gamaSP;
            fpk = forcePk * 1000 / ap;
            fp01k = fpk * 0.9;
            fpd = fpk / gamaSP;
        }

        public enum PrestressingSteelClasses
        {
            [Description("Y1860 S7")]
            y1860s7,
            [Description("cos 2")]
            b,
            [Description("cos 3")]
            c
        }

        public enum PrestressingTypes
        {
            [Description("coś tu poszło nie tak")]
            pp25,
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
