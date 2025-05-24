using Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.InterfacesPrediccion
{
    public interface ISMA
    {
        public string SMA_Prediccion(ActivosDTO activosDTO);
    }
}
