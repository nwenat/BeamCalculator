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
            area = beam.Beam.Dimensions.DimB * (beam.Beam.Dimensions.DimH - beam.Beam.Dimensions.DimD1 - beam.Beam.Dimensions.DimD2)
                + beam.Beam.Dimensions.DimD1 * beam.Beam.Dimensions.DimBD1 + beam.Beam.Dimensions.DimD2 * beam.Beam.Dimensions.DimBD2;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Area"));
        }

    }
}
