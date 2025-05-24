

using Aplication.DTOS;
using Aplication.InterfacesPrediccion;
using Aplication.Prediccion;
using Aplication.Repositories;

namespace Aplication.Services
{
    public class ActivosServices
    {
        public PrediccionListDTO PrediccionListDto { get; set; }
        public readonly ISMA _sma;
        public readonly IRegresionLineal _regresionLineal;
        public readonly IRocMomentum _rocMomentum;

        public ActivosServices()
        {
            _sma = new SMA();
            _regresionLineal = new RegresionLineal();
            _rocMomentum = new RocMomentum();
        }

        public void ActivosPrediccion(ActivosDTO activosdto)
        {
             
            string _SMAResult = _sma.SMA_Prediccion(activosdto);
            activosdto.SMAResult = _SMAResult;
    
            double _RegresionLinealResult = _regresionLineal.regresionLineal(activosdto).Item1;
            string _tendenciaRegresionLineal = _regresionLineal.regresionLineal(activosdto).Item2;
            
            activosdto.RegresionLinealResult = _RegresionLinealResult;
            activosdto.tendenciaRegresionLineal = _tendenciaRegresionLineal;

            activosdto.RocMomentumResult = _rocMomentum.CalculeRocMomentum(activosdto.valorActivo, 5);

            ActivosRepository.Instance.PrediccionList.ActivosPredicciones.Add(activosdto);
        }


        public PrediccionListDTO GetAll()
        {
            return ActivosRepository.Instance.PrediccionList;
        }


    }
}
