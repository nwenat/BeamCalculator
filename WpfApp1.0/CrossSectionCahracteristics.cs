using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1._0
{
    class CrossSectionCahracteristics
    {
        public Double b {
            get;
            set;
        }

        public Double h {
            get;
            set;
        }

        public Double a {
            get {
                return h * b;
            }
        }
    }
}
