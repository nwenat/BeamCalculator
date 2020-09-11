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
        // Sx in [cm3] wzg. gornej krawedzi pola ponad osia (SCINANIE)
        private Double sxCS2;
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

        private Double alfaP;
        private Double hz;
        private Double bNmin;
        private Double bShear;
        // obwod narazony na wysychanie
        private Double u;

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

        public Double AlfaP
        {
            get
            {
                return alfaP;
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

        public Double SxCS2
        {
            get
            {
                return sxCS2;
            }
        }

        public Double Hz
        {
            get
            {
                return hz;
            }
        }

        public Double BNmin
        {
            get
            {
                return bNmin;
            }
        }

        public Double BShear
        {
            get
            {
                return bShear;
            }
        }

        public Double U
        {
            get
            {
                return u;
            }
        }

        public CrossSectionCalculatedCharacteristics(BeamUnderLoad beam)
        {
            Calculate(beam);
        }

        public void Calculate(BeamUnderLoad beam)
        {
            Dimensions d = beam.Beam.Dimensions;

            switch (d.BeamType)
            {
                case Dimensions.BeamTypes.prostokatny:
                    area = d.PrH * d.PrB;
                    sC = 0.5 * d.PrB * Math.Pow(d.PrH, 2);
                    yC = sC / area;
                    iXC = d.PrB * Math.Pow(d.PrH, 3) / 12;
                    break;
                case Dimensions.BeamTypes.dwuteowy:
                    area = d.DimB * (d.DimH - d.DimD1 - d.DimD2)
                        + d.DimD1 * d.DimBD1 + d.DimD2 * d.DimBD2;

                    sC = (d.DimBD1 * d.DimD1 * d.DimD1) / 2
                        + d.DimB * (d.DimH - d.DimD1 - d.DimD2)
                        * ((d.DimH - d.DimD1 - d.DimD2) / 2 + d.DimD1)
                        + d.DimBD2 * d.DimD2 * (d.DimH - d.DimD2 / 2);

                    yC = sC / area;

                    iXC = d.DimB * Math.Pow((d.DimH - d.DimD1 - d.DimD2), 3) / 12
                        + d.DimB * (d.DimH - d.DimD1 - d.DimD2) * Math.Pow((yC - (d.DimH + d.DimD1 - d.DimD2) / 2), 2)
                        + d.DimBD2 * Math.Pow(d.DimD2, 3) / 12
                        + d.DimBD2 * d.DimD2 * Math.Pow((yC - d.DimH + d.DimD2 / 2), 2)
                        + d.DimBD1 * Math.Pow(d.DimD1, 3) / 12 + d.DimBD1 * d.DimD1 * Math.Pow((yC - d.DimD1 / 2), 2);
                    break;
                case Dimensions.BeamTypes.skrzynkowy:
                    area = d.SB1 * d.SH1 + d.SB2 * d.SH2 + 2 * d.SB3 * (d.SH - d.SH1 - d.SH2);
                    sC = d.SB1 * d.SH1 * (d.SH - 0.5 * d.SH1) + 0.5 * d.SB2 * Math.Pow(d.SH2, 2) + 2 * (d.SB3 * (d.SH - d.SH1 - d.SH2) * (d.SH2 + 0.5 * (d.SH - d.SH1 - d.SH2)));
                    yC = sC / area;

                    iXC = d.SB1 * Math.Pow(d.SH1, 3) / 12 + d.SB1 * d.SH1 * Math.Pow(d.SH - 0.5 *d.SH1 - yC , 2) + d.SB2 * Math.Pow(d.SH2, 3) / 12 + d.SB2 * d.SH2 * Math.Pow(yC - d.SH2, 2)
                        + 2 * (d.SB3 * Math.Pow((d.SH - d.SH1 - d.SH2), 3) / 12 + d.SB3 * (d.SH - d.SH1 - d.SH2) * Math.Pow(yC + d.SH2 - 0.5 * (d.SH - d.SH1 - d.SH2), 2));
                    break;
                case Dimensions.BeamTypes.belkatt:
                    area = d.TtHf * d.TtB + 2 * (d.TtH - d.TtHf) * d.TtB1;
                    sC = d.TtHf * d.TtB * (d.TtH - d.TtHf / 2) + d.TtB1 * Math.Pow(d.TtH - d.TtHf, 2);
                    yC = sC / area;
                    iXC = d.TtB * Math.Pow(d.TtHf, 3) / 12 + d.TtB * d.TtHf * Math.Pow(d.TtH - d.TtHf / 2 - yC , 2)
                        + 2 * (d.TtB1 * Math.Pow(d.TtH - d.TtHf, 3) / 12 + d.TtB1 * (d.TtH - d.TtHf) * Math.Pow((d.TtH - d.TtHf) / 2 - yC, 2));
                    break;
                default:
                    area = 1.1;
                    sC = 1.1;
                    yC = 1.1;
                    iXC = 1.1;
                    break;
            }

            alfaP = beam.Beam.PrestressingSteelParameters.EP / beam.Beam.ConcreteParameters.ECm;
            areaAp = beam.Beam.PrestressingSteelParameters.N * beam.Beam.PrestressingSteelParameters.Ap / 100;
            areaAcs = area + (alfaP - 1) * areaAp;

            sCS = sC + (alfaP - 1) * areaAp * d.E1;

            yCS = sCS / areaAcs;

            iXCS = iXC + area * Math.Pow(yCS - yC, 2) + (alfaP - 1) * areaAp * Math.Pow(yCS - d.E1, 2);

            wCSd = iXCS / yCS;
            
            switch (d.BeamType)
            {
                case Dimensions.BeamTypes.prostokatny:
                    wCSg = iXCS / (d.PrH - yCS);
                    sxCS2 = 0.5 * d.PrB * Math.Pow(d.PrH - yCS, 2);
                    hz = d.PrH - d.E1;
                    bNmin = d.PrB;
                    bShear = d.PrB;
                    u = 2 * d.PrH + d.PrB;
                    break;
                case Dimensions.BeamTypes.dwuteowy:
                    wCSg = iXCS / (d.DimH - yCS);
                    sxCS2 = d.DimBD2 * d.DimD2 * (d.DimH - yCS - 0.5 * d.DimD2) + 0.5 * d.DimB * Math.Pow(d.DimH - yCS - d.DimD2, 2);
                    hz = d.DimH - d.E1;
                    bNmin = d.DimBD2;
                    bShear = d.DimB;
                    u = 2 * d.DimH + d.DimBD1;
                    break;
                case Dimensions.BeamTypes.skrzynkowy:
                    wCSg = iXCS / (d.SH - yCS);
                    sxCS2 = d.SB1 * d.SH1 * (d.SH - yCS - 0.5 * d.SH1) + d.SB3 * Math.Pow(d.SH - d.SH1 - yCS, 2);
                    hz = d.SH - d.E1;
                    bNmin = d.SB1;
                    bShear = d.SB3 * 2;
                    u = 4 * d.SH + d.SB2;
                    break;
                case Dimensions.BeamTypes.belkatt:
                    wCSg = iXCS / (d.TtH - yCS);
                    sxCS2 = d.TtB * Math.Pow(d.TtHf, 3) / 12 + d.TtB * d.TtHf * Math.Pow(d.TtH - d.TtHf / 2 - yCS, 2) + 2 * (d.TtB1 * Math.Pow(d.TtH - d.TtHf - yCS, 3) / 12 + 0.5 * d.TtB1 * Math.Pow(d.TtH - d.TtHf - yCS, 2));
                    hz = d.TtH - d.E1;
                    bNmin = d.TtB;
                    bShear = 2 * d.TtB1;
                    u = 4 * d.TtH + 2 * d.TtB1;
                    break;
                default:
                    wCSg = 1.1;
                    sxCS2 = 1.1;
                    hz = 1.1;
                    break;
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXC"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SCS"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IXCS"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WCSd"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WCSg"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlfaP"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AreaAcs"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AreaAp"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SxCS2"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Hz"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BNmin"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BShear"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("U"));
        }

    }
}
