

using Aplication.DTOS;
using Aplication.InterfacesPrediccion;

namespace Aplication.Prediccion
{
    public class RegresionLineal : IRegresionLineal
    {

        public RegresionLineal() { }

        public (double,string) regresionLineal(ActivosDTO activosDTO)
        {
            double sumatoriaY = 0;
            double sumatoriaX = 0;
            double sumatoriaXY = 0;
            double sumatoriaXCuadrado = 0;
            double pendienteM = 0;
            double interceptoB = 0;
            double promX = 0;
            double promY = 0;
            const int n = 20;
            const int x = 21;
            double prediccionRegresionLineal = 0;
            string tendenciaPrediccion = string.Empty;

            foreach (var value in activosDTO.valorActivo)
            {
                sumatoriaY += value;
            }

            for(int i = 0; i < activosDTO.dateActivo.Length; i++)
            {
                double x_i = i + 1;
                double y_i = activosDTO.valorActivo[i];

                sumatoriaX += x_i;
                sumatoriaXCuadrado += x_i * x_i;
                sumatoriaXY += x_i * y_i;
            }

            promX = (double)sumatoriaX / n;
            promY = (double)sumatoriaY / n;

            double numerador = (sumatoriaXY - ((sumatoriaX * sumatoriaY)/n));
            double denominador = (sumatoriaXCuadrado - ((sumatoriaX * sumatoriaX)/n));

            pendienteM = numerador / denominador;

            interceptoB = promY - (pendienteM * promX);

            prediccionRegresionLineal = (pendienteM * x) + interceptoB;

            
            tendenciaPrediccion = pendienteM < 0 ? "Bajista" : "Alcista";

            return (prediccionRegresionLineal, tendenciaPrediccion);
        }
    }
}
