using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.InterfacesPrediccion
{
    public interface IRocMomentum
    {
        public List<double> CalculeRocMomentum(double[] valuesActivos, int nPeriod);
    }
}
