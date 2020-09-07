using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class Dimensions : INotifyPropertyChanged
    {
        // length m
        private Double length = 12.0;

        private BeamTypes beamType = BeamTypes.dwuteowy;
        private String beamTypeDescription = EnumDescribe.GetDescribe(BeamTypes.dwuteowy);

        // dwuteowy cm
        private Double dimH = 100.0;
        private Double dimD1 = 20.0;
        private Double dimBD1 = 40.0;
        private Double dimD2 = 10.0;
        private Double dimBD2 = 70.0;
        private Double dimB = 10.0;

        // prostokat cm
        private Double prH = 200.0;
        private Double prB = 50.0;

        // belka TT cm
        private Double ttH = 100.0;
        private Double ttB = 200.0;
        private Double ttHf = 40.0;
        private Double ttB1 = 70.0;
        private Double ttB2 = 10.0;

        // skrzynkowy cm
        private Double sH = 100.0;
        private Double sH1 = 40.0;
        private Double sH2 = 10.0;
        private Double sB1 = 70.0;
        private Double sB2 = 10.0;
        private Double sB3 = 10.0;

        private Double e1 = 7.5;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value > 0)
                {
                    length = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Length"));
                }
            }
        }

        public Double DimH        {
            get
            {
                return dimH;
            }
            set
            {
                if (value > 0)
                {
                    dimH = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimH"));
                }
            }
        }

        public Double DimD1
        {
            get
            {
                return dimD1;
            }
            set
            {
                if (value >= 0)
                {
                    dimD1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimD1"));
                }
            }
        }

        public Double DimBD1
        {
            get
            {
                return dimBD1;
            }
            set
            {
                if (value >= 0)
                {
                    dimBD1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimBD1"));
                }
            }
        }

        public Double DimD2
        {
            get
            {
                return dimD2;
            }
            set
            {
                if (value >= 0)
                {
                    dimD2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimD2"));
                }
            }
        }

        public Double DimBD2
        {
            get
            {
                return dimBD2;
            }
            set
            {
                if (value >= 0)
                {
                    dimBD2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimBD2"));
                }
            }
        }

        public Double DimB
        {
            get
            {
                return dimB;
            }
            set
            {
                if (value > 0)
                {
                    dimB = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DimB"));
                }
            }
        }

        public Double E1
        {
            get
            {
                return e1;
            }
            set
            {
                if (value > 0)
                {
                    e1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("E1"));
                }
            }
        }

        public Double PrH
        {
            get
            {
                return prH;
            }
            set
            {
                if (value > 0)
                {
                    prH = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PrH"));
                }
            }
        }

        public Double PrB
        {
            get
            {
                return prB;
            }
            set
            {
                if (value > 0)
                {
                    prB = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PrB"));
                }
            }
        }

        public Double TtH
        {
            get
            {
                return ttH;
            }
            set
            {
                if (value > 0)
                {
                    ttH = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TtH"));
                }
            }
        }

        public Double TtB
        {
            get
            {
                return ttB;
            }
            set
            {
                if (value > 0)
                {
                    ttB = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TtB"));
                }
            }
        }

        public Double TtHf
        {
            get
            {
                return ttHf;
            }
            set
            {
                if (value > 0)
                {
                    ttHf = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TtHf"));
                }
            }
        }

        public Double TtB1
        {
            get
            {
                return ttB1;
            }
            set
            {
                if (value > 0)
                {
                    ttB1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TtB1"));
                }
            }
        }

        public Double TtB2
        {
            get
            {
                return ttB2;
            }
            set
            {
                if (value > 0)
                {
                    ttB2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TtB2"));
                }
            }
        }

        public Double SH
        {
            get
            {
                return sH;
            }
            set
            {
                if (value > 0)
                {
                    sH = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SH"));
                }
            }
        }

        public Double SH1
        {
            get
            {
                return sH1;
            }
            set
            {
                if (value > 0)
                {
                    sH1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SH1"));
                }
            }
        }

        public Double SB3
        {
            get
            {
                return sB3;
            }
            set
            {
                if (value > 0)
                {
                    sB3 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SB3"));
                }
            }
        }

        public Double SH2
        {
            get
            {
                return sH2;
            }
            set
            {
                if (value > 0)
                {
                    sH2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SH2"));
                }
            }
        }

        public Double SB1
        {
            get
            {
                return sB1;
            }
            set
            {
                if (value > 0)
                {
                    sB1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SB1"));
                }
            }
        }

        public Double SB2
        {
            get
            {
                return sB2;
            }
            set
            {
                if (value > 0)
                {
                    sB2 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SB2"));
                }
            }
        }

        public BeamTypes BeamType
        {
            get
            {
                return beamType;
            }
        }

        public Array TypesOfBeam
        {
            get
            {
                List<BeamTypes> list = Enum.GetValues(typeof(BeamTypes)).OfType<BeamTypes>().ToList();
                List<String> result = new List<String>();
                foreach (BeamTypes sC in list)
                {
                    var descript = EnumDescribe.GetDescribe(sC);
                    result.Add(descript);
                }
                return result.ToArray();
            }
        }

        public String BeamTypeDescription
        {
            set
            {
                beamTypeDescription = value;
                beamType = EnumDescribe.GetValueFromDescription<BeamTypes>(beamTypeDescription);
                PropertyChanged(this, new PropertyChangedEventArgs("BeamTypeDescription"));
            }
            get
            {
                return beamTypeDescription;
            }
        }

        public enum BeamTypes
        {
            [Description("Prostokątny")]
            prostokatny,
            [Description("Dwuteowy")]
            dwuteowy,
            [Description("Skrzynkowy")]
            skrzynkowy,
            [Description("Belka TT")]
            belkatt
        }
    }
}
