

using Aplication.DTOS;
using Aplication.InterfacesPrediccion;

namespace Aplication.Prediccion
{
    public class SMA : ISMA
    {
        public SMA() { }

        public string SMAresult;
        public string SMA_Prediccion(ActivosDTO activos)
        {
            double SMALong = 0;
            double SMAShort = 0;
            double[] numbers = new double [20];
            double[] lastFiveNumbers = new double[5];
            int cont = activos.valorActivo.Length - 1;


            // Check if the length of valorActivo and dateActivo is 20
            if (activos.valorActivo.Length != 20 || activos.dateActivo.Length != 20)
            {
                return "We need 20 values and 20 dates, beach";
            }

            foreach (var value in activos.valorActivo)
            {
                SMALong += value;
            }

            for (int i = 0; i < lastFiveNumbers.Length; i++)
            {
               lastFiveNumbers[i] = activos.valorActivo[cont];
                cont--;

                if(i == 5 - 1)
                {
                    foreach (var value in lastFiveNumbers) 
                    { 
                        SMAShort += value;
                    }
                }

            }

            SMALong = SMALong / activos.valorActivo.Length;
            SMAShort = SMAShort / lastFiveNumbers.Length;

            if (SMAShort > SMALong)
            {
                SMAresult = "Alcista";
            }else 
            {
                SMAresult = "Bajista";
            }
                
            return SMAresult;
        }
    }
}
