using Clases;
using Clases.Ordenamiento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    [LoginFilter]
    public class PagosController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;
        public IActionResult Index(string error)
        {
            int usuarioId = (int)HttpContext.Session.GetInt32("Id");
            Usuario usuario = _sistema.BuscarUsuarioPorID(usuarioId);
            List<Pago> misPagos = new List<Pago>();

            foreach (Pago pago in _sistema.Pagos)
            {

                if (pago.Usuario != null && pago.Usuario.Id == usuario.Id)
                {
                    misPagos.Add(pago);
                }
            }

            if (usuario != null && !usuario.EsGerente())
            {
                if (misPagos.Count > 0)
                {

                    misPagos.Sort(new OrdenarXMontoTotalDescendente());
                }
            }
            ViewBag.EmailUsuario = usuario.Email;
            ViewBag.Mensaje = error;
            return View(misPagos);
        }

        public IActionResult AgregarPagoUnico(int id)
        {
            ViewBag.Gastos = _sistema.Gastos;
            ViewBag.MetodoPago = Enum.GetValues(typeof(MetodoPago));
            ViewBag.PagoId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AgregarPagoUnico(PagoUnico nuevo, int TipoDeGasto)
        {
            try
            {
                int gastoId = TipoDeGasto;
                Gasto gasto = _sistema.BuscarGastoPorID(gastoId);
                nuevo.TipoDeGasto = gasto;
                int usuarioId = (int)HttpContext.Session.GetInt32("Id");
                Usuario usuario = _sistema.BuscarUsuarioPorID(usuarioId);
                nuevo.Usuario = usuario;
                _sistema.AltaPago(nuevo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Gastos = _sistema.Gastos;
                ViewBag.MetodoPago = Enum.GetValues(typeof(MetodoPago));
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public IActionResult AgregarPagoRecurrente(int id)
        {
            ViewBag.Gastos = _sistema.Gastos;
            ViewBag.MetodoPago = Enum.GetValues(typeof(MetodoPago));
            ViewBag.PagoId = id;
            return View(new PagoRecurrente());
        }

        [HttpPost]
        public IActionResult AgregarPagoRecurrente(PagoRecurrente nuevo, int TipoDeGasto)
        {
            try
            {
                int gastoId = TipoDeGasto;
                Gasto gasto = _sistema.BuscarGastoPorID(gastoId);
                nuevo.TipoDeGasto = gasto;
                int usuarioId = (int)HttpContext.Session.GetInt32("Id");
                Usuario usuario = _sistema.BuscarUsuarioPorID(usuarioId);
                nuevo.Usuario = usuario;
                _sistema.AltaPago(nuevo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Gastos = _sistema.Gastos;
                ViewBag.MetodoPago = Enum.GetValues(typeof(MetodoPago));
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [GerenteFilter]
        public IActionResult ListadoPagosEquipo(int? mes, int? anio)
        {
            int? idUser = HttpContext.Session.GetInt32("Id");
            if (idUser == null) return RedirectToAction("Login", "Usuario");
            Usuario gerente = _sistema.BuscarUsuarioPorID((int)idUser);

            int mesFiltro;
            int anioFiltro;
            if (mes == null || anio == null)
            {
                mesFiltro = DateTime.Now.Month;
                anioFiltro = DateTime.Now.Year;
            }
            else
            {
                mesFiltro = (int)mes;
                anioFiltro = (int)anio;
            }
            List<Pago> listado = _sistema.FiltrarPagosPorGerenteYFecha(gerente, mesFiltro, anioFiltro);
            if (listado != null && listado.Count > 0)
            {
                listado.Sort(new OrdenarXMontoTotalDescendente());
            }
            ViewBag.Mes = mesFiltro;
            ViewBag.Anio = anioFiltro;
            return View(listado);
        }

    }



}