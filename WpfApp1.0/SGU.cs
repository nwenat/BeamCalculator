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
        // qp in [kN/m] suma obciazen charakterystycznych
        private Double q;
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
            q = beam.Beam.Loads.DGLoad + beam.Beam.Loads.QLoad + beam.Forces.G;
            // wzory ogarnac!!!!!!!!!
            eCeff = 9985.0; // zle
            u = (5 * (q/100) * Math.Pow(beam.Beam.Dimensions.Length * 100, 4)) / (384 * (eCeff/10) * beam.CrossSectionCalculatedCharacteristics.IXCS);
            s = 150.0; // zle
            uU = u + s;
            condition = beam.Beam.Dimensions.Length*100 / 250;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ECeff"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("S"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("U"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UU"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Condition"));
        }

    }
}
