using Aplication.InterfacesPrediccion;

namespace Aplication.Prediccion
{
    public class RocMomentum : IRocMomentum
    {
        public List<double> CalculeRocMomentum(double[] valoresActivos, int nPeriod)
        {
            if(valoresActivos == null || valoresActivos.Length == 0)
            {
                throw new ArgumentException("El array de valores activos no puede ser nulo o vacío.");
            }
            if(nPeriod <= 0)
            {
                throw new ArgumentException("El periodo debe ser mayor que cero.");
            }

            if(nPeriod > valoresActivos.Length)
            {
                return Enumerable.Repeat(double.NaN, valoresActivos.Length).ToList();
            }

            List<double> momentum = new List<double>(valoresActivos.Length);

            for (int i = 0; i < nPeriod; i++)
            {
                momentum.Add(double.NaN);
            }

            for (int i = nPeriod; i < valoresActivos.Length; i++)
            {
                double currentValue = valoresActivos[i];
                double pastValue = valoresActivos[i - nPeriod];

                if (pastValue == 0)
                {
                    momentum.Add(double.NaN);
                }
                else
                {
                    double roc = ((currentValue / pastValue) - 1) * 100;
                    momentum.Add(roc);
                }
            }

            return momentum;
        }

    }
}
