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


        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateData()
        {
            Calculate();
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClassDescription"));
            PropertyChanged(this, new PropertyChangedEventArgs("SteelClass"));
            PropertyChanged(this, new PropertyChangedEventArgs("GamaC"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fck"));
            PropertyChanged(this, new PropertyChangedEventArgs("Fcm"));
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
