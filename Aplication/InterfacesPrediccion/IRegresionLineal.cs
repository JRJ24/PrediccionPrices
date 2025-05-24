

using Aplication.DTOS;

namespace Aplication.InterfacesPrediccion
{
    public interface IRegresionLineal
    {
        public (double,string) regresionLineal(ActivosDTO activosDTO);
        
    }
}
