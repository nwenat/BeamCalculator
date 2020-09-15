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
            
            eCeff = beam.Beam.ConcreteParameters.ECm * 1000 / (1 + beam.DelayedLosses.Fi8T0);

            u = (5 * (q/100) * Math.Pow(beam.Beam.Dimensions.Length * 100, 4)) / (384 * (eCeff/10) * beam.CrossSectionCalculatedCharacteristics.IXCS);

            double l3EI = Math.Pow(beam.Beam.Dimensions.Length * 100, 3) / ((eCeff / 10) * beam.CrossSectionCalculatedCharacteristics.IXCS);

            switch (beam.Beam.Loads.StaticSystem)
            {
                case Loads.StaticSystemTypes.jednoprzeslowa:
                    u = (5 / 384) * (q / 100) * beam.Beam.Dimensions.Length * l3EI + (1/48) * beam.Beam.Loads.SilaP * l3EI;
                    break;
                //case Loads.StaticSystemTypes.przewieszenie:
                //    u = 0.0;
                //    break;
                case Loads.StaticSystemTypes.jednoZamocowanie:
                    u = 0.00541 * (q / 100) * beam.Beam.Dimensions.Length * l3EI + 0.00933 * beam.Beam.Loads.SilaP * l3EI;
                    break;
                case Loads.StaticSystemTypes.dwaZamocowania:
                    u = 0.0026 * (q / 100) * beam.Beam.Dimensions.Length * l3EI + 0.00521 * beam.Beam.Loads.SilaP * l3EI;
                    break;
                default:
                    break;
            }



            s = (-1.0 / 8.0) * (beam.DelayedLosses.Pmt * beam.AdHocLosses.Zcp * Math.Pow(beam.Beam.Dimensions.Length * 100, 2) / ((eCeff / 10) * beam.CrossSectionCalculatedCharacteristics.IXCS));
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
