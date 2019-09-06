using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class SteelParameters : INotifyPropertyChanged
    {
        private SteelClasses steelClasses = SteelClasses.a;
        private String steelClassDescription = EnumDescribe.GetDescribe(SteelClasses.a);
        private Double gamaS = 1.15;
        // fck and fyd in [MPa]
        private int fyk = 500;
        private Double fyd = 434.78;
        // Es in [Gpa]
        private Double eS = 200.0;
        // fi [mm]
        private int fi = 12;
        private int fiS = 8;

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
                steelClasses = EnumDescribe.GetValueFromDescription<SteelClasses>(steelClassDescription);
                switch (steelClasses)
                {
                    case SteelClasses.a:
                        break;
                    case SteelClasses.b:
                        break;
                    case SteelClasses.c:
                        break;
                }
                UpdateData();
            }
            get
            {
                return steelClassDescription;
            }
        }

        public int Fi
        {
            set
            {
                fi = value;
                UpdateData();
            }
            get
            {
                return fi;
            }
        }

        public int FiS
        {
            set
            {
                fiS = value;
                UpdateData();
            }
            get
            {
                return fiS;
            }
        }

        public Array TypesOfSteel
        {
            get
            {
                List<SteelClasses> list = Enum.GetValues(typeof(SteelClasses)).OfType<SteelClasses>().ToList();
                List<String> result = new List<String>();
                foreach (SteelClasses sC in list)
                {
                    var descript = EnumDescribe.GetDescribe(sC);
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

        public enum SteelClasses
        {
            [Description("RB500 W")]
            a,
            [Description("cos 2")]
            b,
            [Description("cos 3")]
            c
        }
    }
}
