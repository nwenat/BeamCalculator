using System;
using System.ComponentModel;

namespace WpfApp1._0
{
    class CrossSectionCalculatedCharacteristics : INotifyPropertyChanged
    {
        // area in [cm2]
        private Double area = 0.0;
        private Double areaConcrete = 0.0;
        private Double areaAs1 = 0.0;
        private Double areaAp = 0.0;

        // Sx in [cm3]

        // Ix in [cm4]

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
