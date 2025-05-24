
using System.ComponentModel.DataAnnotations;

namespace Aplication.ViewModels
{
    public class ActivosViewModel
    {
        [Required(ErrorMessage = "We need 20 values, beach")]
        public double[] valorActivo { get; set; } = new double[20];
        [Required(ErrorMessage = "We need 20 dates, beach")]
        public string[] dateActivo { get; set; } = new string[20];
        public string? SMAResult { get; set; }
        public double? RegresionLinealResult { get; set; }
        public string? tendenciaRegresionLineal { get; set; }
        public List<double>? RocMomentumResult { get; set; } = new List<double>();
    }
}
