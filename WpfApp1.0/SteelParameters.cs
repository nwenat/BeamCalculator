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
        private SteelClasses steelClasses = SteelClasses.rb500w;
        private String steelClassDescription = EnumDescribe.GetDescribe(SteelClasses.rb500w);
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
                    case SteelClasses.rb500w:
                        fyk = 500;
                        break;
                    case SteelClasses.rb500:
                        fyk = 500;
                        break;
                    case SteelClasses.g20:
                        fyk = 490;
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
            PropertyChanged(this, new PropertyChangedEventArgs("GamaS"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fyk"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fyd"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fi"));
            PropertyChanged(this, new PropertyChangedEventArgs("FiS"));
        }

        public void Calculate()
        {
            fyd = fyk / gamaS;
        }

        public enum SteelClasses
        {
            [Description("RB500W")]
            rb500w,
            [Description("RB500")]
            rb500,
            [Description("20G2VY-b")]
            g20
        }
    }
}
