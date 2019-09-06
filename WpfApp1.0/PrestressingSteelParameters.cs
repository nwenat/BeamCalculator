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
        private PrestressingSteelClasses prestressingSteelClasses = PrestressingSteelClasses.a;
        private String steelClassDescription = EnumDescribe.GetDescribe(PrestressingSteelClasses.a);
        private Double gamaS = 1.15;
        // fck and fyd in [MPa]
        private int fyk = 500;
        private Double fyd = 434.78;
        // Es in [Gpa]
        private Double eS = 200.0;
        // fi [mm]
        private int fiP = 12;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double GamaS
        {
            get
            {
                return gamaS;
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

        public Double ES
        {
            get
            {
                return eS;
            }
        }

        public String SteelClassDescription
        {
            set
            {
                steelClassDescription = value;
                prestressingSteelClasses = EnumDescribe.GetValueFromDescription<PrestressingSteelClasses>(steelClassDescription);
                switch (prestressingSteelClasses)
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
                return steelClassDescription;
            }
        }

        public int FiP
        {
            set
            {
                fiP = value;
                UpdateData();
            }
            get
            {
                return fiP;
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

        public Array FiArray
        {
            get
            {
                return new int[] { 8, 10, 12, 16, 20, 22 };
            }
        }

        public Array FiSArray
        {
            get
            {
                return new int[] { 6, 8 };
            }
        }

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClassDescription"));
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("GamaC"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fck"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fcm"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fi"));
            PropertyChanged(this, new PropertyChangedEventArgs("FiS"));
        }

        public void Calculate()
        {
            fyd = fyk / gamaS;
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

        public enum PrestressingCrossSections
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
