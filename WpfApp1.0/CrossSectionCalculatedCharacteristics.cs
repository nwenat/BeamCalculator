using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCalculatedCharacteristics : INotifyPropertyChanged
    {
        // area in [cm2]
        private Double area;
        private Double areaAs1;
        private Double areaAp = 0.0;
        private Double areaAcs;
        // Sx in [cm3] wzg. gornej krawedzi
        private Double sC;
        private Double sCS;
        // Ix in [cm4]
        // iXC wzg. gornej krawedzi
        private Double iXC;
        private Double iXCS;
        // yc in [cm]
        private Double yC;
        private Double yCS;
        // Wcs in [cm3]
        private Double wCSd;
        private Double wCSg;

        private Double alfa;


        public event PropertyChangedEventHandler PropertyChanged;


        public Double Area
        {
            get
            {
                return area;
            }
        }

        public Double AreaAcs
        {
            get
            {
                return areaAcs;
            }
        }

        public Double AreaAp
        {
            get
            {
                return areaAp;
            }
        }

        public Double SC
        {
            get
            {
                return sC;
            }
        }

        public Double IXC
        {
            get
            {
                return iXC;
            }
        }

        public Double SCS
        {
            get
            {
                return sCS;
            }
        }

        public Double IXCS
        {
            get
            {
                return iXCS;
            }
        }

        public Double Alfa
        {
            get
            {
                return alfa;
            }
        }

        public Double WCSd
        {
            get
            {
                return wCSd;
            }
        }

        public Double WCSg
        {
            get
            {
                return wCSg;
            }
        }

        public Double YC
        {
            get
            {
                return yC;
            }
        }

        public Double YCS
        {
            get
            {
                return yCS;
            }
        }

        public CrossSectionCalculatedCharacteristics(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            Dimensions d = beam.Beam.Dimensions;

            if (d.DimBD1 == 0 & d.DimBD2 == 0)
            {
                area = d.DimB * d.DimH;
            }
            else if (d.DimBD1 != 0 & d.DimBD2 == 0)
            {
                area = d.DimB * (d.DimH - d.DimD1) + d.DimD1 * d.DimBD1;
            }
            else if (d.DimBD1 == 0 & d.DimBD2 != 0)
            {
                area = d.DimB * (d.DimH - d.DimD2) + d.DimD2 * d.DimBD2;
            }
            else
            {
                area = d.DimB * (d.DimH - d.DimD1 - d.DimD2)
                + d.DimD1 * d.DimBD1 + d.DimD2 * d.DimBD2;
            }

            sC = (d.DimBD1 * d.DimD1 * d.DimD1) / 2
                + d.DimB * (d.DimH - d.DimD1 - d.DimD2)
                * ((d.DimH - d.DimD1 - d.DimD2) /2 + d.DimD1)
                + d.DimBD2 * d.DimD2 * (d.DimH - d.DimD2 / 2);

            yC = sC / area;

            iXC = d.DimB * Math.Pow((d.DimH - d.DimD1 - d.DimD2), 3)  / 12
                + d.DimB * (d.DimH - d.DimD1 - d.DimD2) * Math.Pow((yC - (d.DimH + d.DimD1 - d.DimD2) / 2), 2) 
                + d.DimBD2 * Math.Pow(d.DimD2, 3) / 12
                + d.DimBD2 * d.DimD2 * Math.Pow((yC - d.DimH + d.DimD2 / 2), 2)
                + d.DimBD1 * Math.Pow(d.DimD1, 3) / 12 + d.DimBD1 * d.DimD1 * Math.Pow((yC - d.DimD1 / 2), 2);

            alfa = beam.Beam.PrestressingSteelParameters.EP / beam.Beam.ConcreteParameters.ECm;

            areaAp = beam.Beam.PrestressingSteelParameters.N * beam.Beam.PrestressingSteelParameters.Ap / 100;

            areaAcs = area + (alfa - 1) * areaAp;

            sCS = sC + (alfa - 1) * areaAp * d.E1;

            yCS = sCS / areaAcs;

            iXCS = iXC + area * (yCS - yC) * (yCS - yC) + (alfa -1) * areaAp * (yCS - d.E1) * (yCS - d.E1);

            wCSd = iXCS / yCS;
            wCSg = iXCS / (d.DimH - yCS);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SCS"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXCS"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WCSd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WCSg"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alfa"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AreaAcs"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AreaAp"));
        }

    }
}
