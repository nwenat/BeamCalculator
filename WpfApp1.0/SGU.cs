using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class SGU : INotifyPropertyChanged
    {
        // Eceff in [MPa] efektywny modul sprezystosci betonu
        private Double eCeff;
        // u in [cm] wartosc ugiec bez uwzg. strzalki odwrotnej
        private Double u;
        // s in [cm] wartosc strzalki odwrotnej
        private Double s;
        // U in [cm] ugiecia calkowite
        private Double uU;
        // Leff/250 in [cm] warunek
        private Double condition;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double ECeff
        {
            get
            {
                return eCeff;
            }
        }

        public Double U
        {
            get
            {
                return u;
            }
        }

        public Double S
        {
            get
            {
                return s;
            }
        }

        public Double UU
        {
            get
            {
                return uU;
            }
        }

        public Double Condition
        {
            get
            {
                return condition;
            }
        }

        public SGU(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            // wzory ogarnac!!!!!!!!!
            eCeff = 10.0;
            s = 150.0;
            u = 20.0;
            uU = 30.0;
            condition = 40.0;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ECeff"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("S"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("U"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UU"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Condition"));
        }

    }
}
