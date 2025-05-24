using Aplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repositories
{
    public sealed class ActivosRepository
    {
        public ActivosRepository(){ }

        public static ActivosRepository Instance { get; } = new ActivosRepository();

        public PrediccionListDTO PrediccionList { get; set; } = new()
        {
            ActivosPredicciones = new List<ActivosDTO>(),
        };

    }
}
