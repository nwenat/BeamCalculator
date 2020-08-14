using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class DifferentData : INotifyPropertyChanged
    {
        // straty technologiczne - maksymalny poslizg ciegien [mm]
        private Double as1 = 3.0;
        // czas ktory uplynol od sprezeniea [h] STRATY DORAZNA (AD HOC)
        private Double tDorazne = 336.0;

        // klasa cementu: S, N, R
        private string klasaCem = "N";

        // wilgotnosc wzgledna otoczenia [%]
        private int rH = 50;

        // czas dla ktorego obliczany jest calkowity skurcz betonu [lata] STRATY OPOZNIONE (DELAYED)
        private Double tOpoznione =57.0;
        // wiek betonu na poczatku procesu wysychania [dni] STRATY OPOZNIONE (DELAYED)
        private Double tsOpoznione = 57.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Double As1
        {
            get
            {
                return as1;
            }
            set
            {
                if (value > 0)
                {
                    as1 = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("As1"));
                }
            }
        }

        public Double TDorazne
        {
            get
            {
                return tDorazne;
            }
            set
            {
                if (value > 0)
                {
                    tDorazne = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TDorazne"));
                }
            }
        }

        public Double TOpoznione
        {
            get
            {
                return tOpoznione;
            }
            set
            {
                if (value > 0)
                {
                    tOpoznione = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TOpoznione"));
                }
            }
        }

        public Double TsOpoznione
        {
            get
            {
                return tsOpoznione;
            }
            set
            {
                if (value > 0)
                {
                    tsOpoznione = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("TsOpoznione"));
                }
            }
        }

        public String KlasaCem
        {
            get
            {
                return klasaCem;
            }
            set
            {
                klasaCem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("KlasaCem"));
            }
        }

        public int RH
        {
            get
            {
                return rH;
            }
            set
            {
                rH = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RH"));
            }
        }
    }
}
