using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class CompressionType : INotifyPropertyChanged
    {
        private CompressionBeamType compression = CompressionBeamType.kablobeton;

        public event PropertyChangedEventHandler PropertyChanged;

        public CompressionBeamType Compression
        {
            get
            { return compression; }
            set
            { compression = value; }
        }

        public void UpdateData()
        {
            PropertyChanged(this, new PropertyChangedEventArgs("CompressionBeamType"));
        }

        public enum CompressionBeamType
        {
            strunobeton,
            kablobeton
        }
    }
}
