using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionProperties : INotifyPropertyChanged
    {
        private Double width = 5.0;
        private Double height = 10.0;
        private Double widthEff = 10.0;
        private Double heightF = 5.0;
        // fi in [mm]
        private int fiAs1 = 8;
        private int fiAp = 8;
        private TypeOfCrossSection type = TypeOfCrossSection.prostokatny;
        private String pathToDraw = "D:/DEV/C#/Magisterka/WpfApp1.0/WpfApp1.0/Draws/foka1.jpgggg.";

        public event PropertyChangedEventHandler PropertyChanged;

        public Double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0)
                {
                    width = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Width"));
                }
                UpdateData();
            }
        }

        public Double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Height"));
                }
                UpdateData();
            }
        }

        public Double WidthEff
        {
            get
            {
                return widthEff;
            }
            set
            {
                if (value > 0)
                {
                    widthEff = value;
                }
                UpdateData();
            }
        }

        public Double HeightF
        {
            get
            {
                return heightF;
            }
            set
            {
                if (value > 0)
                {
                    heightF = value;
                }
                UpdateData();
            }
        }

        public int FiAs1
        {
            get
            {
                return fiAs1;
            }
            set
            {
                if (value > 0)
                {
                    fiAs1 = value;
                }
                UpdateData();
            }
        }

        public int FiAp
        {
            get
            {
                return fiAp;
            }
            set
            {
                if (value > 0)
                {
                    fiAp = value;
                }
                UpdateData();
            }
    }

        public TypeOfCrossSection Type
        {
            get
            { return type; } 
            set
            {
                type = value;
                UpdateData();
            }
        }

        public String PathToDraw
        {
            get
            {
                if (type.Equals(TypeOfCrossSection.prostokatny))
                {
                    return pathToDraw;
                }
                else
                {
                    return "D:/DEV/C#/Magisterka/WpfApp1.0/WpfApp1.0/Draws/foka2.jpggggg";
                }
            }
            set
            { pathToDraw = value;
                UpdateData();
            }
        }

        public Array ArrayOfType
        {
            get
            {
                return Enum.GetValues(typeof(TypeOfCrossSection));
            }
        }

        public void UpdateData()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Type"));
            PropertyChanged(this, new PropertyChangedEventArgs("PathToDraw"));
            PropertyChanged(this, new PropertyChangedEventArgs("IsTeowy"));
        }

        public bool IsTeowy
        {
            get
            {
                if (type.Equals(TypeOfCrossSection.prostokatny))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public enum TypeOfCrossSection
        {
            prostokatny,
            teowy
        }
    }
}
