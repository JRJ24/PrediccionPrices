using Microsoft.AspNetCore.Mvc;
using Aplication.ViewModels;
using Aplication.Services;
using Aplication.DTOS;
using System.Linq;

namespace PrediccionTendenciasActivos.Controllers
{
    public class ActivosController : Controller
    {
       // private readonly ILogger<ActivosController> _logger;
        private readonly ActivosServices _activosServices;

        public ActivosController()
        {
            _activosServices = new ActivosServices();
           // _logger = logger;
        }

        public IActionResult Home(string? message = null, string? messageType = null)
        {
            PrediccionListDTO prediccionList = _activosServices.GetAll();

            PrediccionListViewModel prediccionListViewModel = new PrediccionListViewModel()
            {
                ActivosPredicciones = prediccionList.ActivosPredicciones.Select(a => new ActivosViewModel()
                {
                    valorActivo = a.valorActivo,
                    dateActivo = a.dateActivo,
                    SMAResult = a.SMAResult,
                    RegresionLinealResult = a.RegresionLinealResult,
                    tendenciaRegresionLineal = a.tendenciaRegresionLineal,
                    RocMomentumResult = a.RocMomentumResult,
                }).ToList(),
            };

            ViewBag.Message = message;
            ViewBag.MessageType = messageType;

            return View(prediccionListViewModel); 
        }

        public IActionResult Modos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Modos(ActivosViewModel AVM)
        {

            try
            {
                if (!ModelState.IsValid || AVM.valorActivo == null || AVM.dateActivo == null)
                {
                    return View();
                }

                _activosServices.ActivosPrediccion(new ActivosDTO()
                {
                    valorActivo = AVM.valorActivo,
                    dateActivo = AVM.dateActivo,
                });

                return RedirectToAction("Home", new { message = "Predicci�n realizada con �xito", messageType = "success" });
            }
            catch(System.Exception ex)
            {
                return RedirectToAction("Modos", new { message = "Error: " + ex.Message, messageType = "error" });
            }
            
        }
    }
}
