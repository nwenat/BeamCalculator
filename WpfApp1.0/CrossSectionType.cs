using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionType : INotifyPropertyChanged
    {
        private TypeOfCrossSection type = TypeOfCrossSection.prostokatny;
        private List<TypeOfCrossSection> listOfType = new List<TypeOfCrossSection>();

        public event PropertyChangedEventHandler PropertyChanged;

        public TypeOfCrossSection Type
        {
            get
            { return type; }
            set
            { type = value; }
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
        }

        public enum TypeOfCrossSection
        {
            prostokatny,
            teowy
        }
    }
}
