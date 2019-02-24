using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionType : INotifyPropertyChanged
    {
        private TypeOfCrossSection type = TypeOfCrossSection.prostokatny;
        private String pathToDraw = "D:/DEV/C#/Magisterka/WpfApp1.0/WpfApp1.0/Draws/foka1.jpg";

        public event PropertyChangedEventHandler PropertyChanged;

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
                    return "D:/DEV/C#/Magisterka/WpfApp1.0/WpfApp1.0/Draws/foka2.jpg";
                }
            }
            set
            { pathToDraw = value; }
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
        }

        public enum TypeOfCrossSection
        {
            prostokatny,
            teowy
        }
    }
}
