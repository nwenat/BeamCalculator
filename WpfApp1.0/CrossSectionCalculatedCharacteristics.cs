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

        public Double AreaAs1
        {
            get
            {
                return areaAs1;
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

            iXC = d.DimB * (d.DimH - d.DimD1 - d.DimD2) * (d.DimH - d.DimD1 - d.DimD2) * (d.DimH - d.DimD1 - d.DimD2) / 12
                + d.DimB * (d.DimH - d.DimD1 - d.DimD2) * (yC - (d.DimH + d.DimD1 - d.DimD2)/2) * (yC - (d.DimH + d.DimD1 - d.DimD2) / 2)
                + d.DimBD2 * d.DimD2 * d.DimD2 * d.DimD2 / 12
                + d.DimBD2 * d.DimD2 * (yC - d.DimH + d.DimD2/2) * (yC - d.DimH + d.DimD2 / 2)
                + d.DimBD1 * d.DimD1 * d.DimD1 * d.DimD1 / 12 + d.DimBD1 * d.DimD1 * (yC - d.DimD1/2) * (yC - d.DimD1 / 2);

            alfa = beam.Beam.PrestressingSteelParameters.EP / beam.Beam.ConcreteParameters.ECm;

            areaAcs = area + (alfa - 1) * areaAp;

            sCS = sC + (alfa - 1) * areaAp;

            yCS = sCS / areaAcs;

            iXCS = iXC + area * (yCS - yC) * (yCS - yC) + (alfa -1) * areaAp * (yCS);

            wCSd = iXCS / yCS;
            wCSg = iXCS / (d.DimH - yCS);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXC"));
        }

    }
}
