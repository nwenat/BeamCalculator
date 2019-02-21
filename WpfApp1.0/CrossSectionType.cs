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

        public List<TypeOfCrossSection> ListOfType
        {
            get
            {
                listOfType.Clear();
                listOfType.Add(TypeOfCrossSection.prostokatny);
                listOfType.Add(TypeOfCrossSection.teowy);
                return listOfType;
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
