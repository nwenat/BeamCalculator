using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCalculatedCharacteristics : INotifyPropertyChanged
    {
        // area in [cm2]
        private Double area;
        private Double areaConcrete;
        private Double areaAs1;
        private Double areaAp;
        // Sx in [cm3] wzg. gornej krawedzi
        private Double sC;
        // Ix in [cm4]
        // iXC wzg. gornej krawedzi
        private Double iXC;
        // yc in [cm]
        private Double yc;


        public event PropertyChangedEventHandler PropertyChanged;


        public Double Area
        {
            get
            {
                return area;
            }
        }

        public Double AreaConcrete
        {
            get
            {
                return areaConcrete;
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

            yc = sC / area;

            iXC = d.DimB * (d.DimH - d.DimD1 - d.DimD2) * (d.DimH - d.DimD1 - d.DimD2) * (d.DimH - d.DimD1 - d.DimD2) / 12
                + d.DimB * (d.DimH - d.DimD1 - d.DimD2) * (yc - (d.DimH + d.DimD1 - d.DimD2)/2) * (yc - (d.DimH + d.DimD1 - d.DimD2) / 2)
                + d.DimBD2 * d.DimD2 * d.DimD2 * d.DimD2 / 12
                + d.DimBD2 * d.DimD2 * (yc - d.DimH + d.DimD2/2) * (yc - d.DimH + d.DimD2 / 2)
                + d.DimBD1 * d.DimD1 * d.DimD1 * d.DimD1 / 12 + d.DimBD1 * d.DimD1 * (yc - d.DimD1/2) * (yc - d.DimD1 / 2);

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXC"));
        }

    }
}
