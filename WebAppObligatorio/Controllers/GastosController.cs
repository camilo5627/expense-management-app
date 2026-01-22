using Clases;
using Microsoft.AspNetCore.Mvc;

namespace WebAppObligatorio.Controllers
{
    public class GastosController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index()
        {
            return View(_sistema.Gastos);
        }

        public IActionResult AgregarGasto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarGasto(Gasto nuevoGasto)
        {
            try
            {
                _sistema.AltaGasto(nuevoGasto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult EliminarGasto()
        {
            ViewBag.Gastos = _sistema.Gastos;
            return View();
        }

        [HttpPost]
        public IActionResult EliminarGasto(int TipoDeGasto)
        {
            try
            {
                Gasto gasto = _sistema.BuscarGastoPorID(TipoDeGasto);
                _sistema.BajaGasto(gasto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Gastos = _sistema.Gastos;
                return View();
            }

        }
    }
}