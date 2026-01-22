using Clases;
using Microsoft.AspNetCore.Mvc;
using WebAppObligatorio.Filters;

namespace WebAppObligatorio.Controllers
{
    public class UsuarioController : Controller
    {

        private Sistema _sistema = Sistema.Instancia;
        [LoginFilter]
        [GerenteFilter]
        public IActionResult Index()
        {
            return View(_sistema.Usuarios);
        }

        public IActionResult Login(string error)
        {
            ViewBag.Mensaje = error;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasenia)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contrasenia))
                {
                    return View();
                }
                Usuario usuario = _sistema.BuscarUsuarioPorMail(email);
                if (contrasenia == usuario.Contrasenia)
                {
                    HttpContext.Session.SetInt32("Id", usuario.Id);
                    HttpContext.Session.SetString("Rol", usuario.Rol.ToString());
                    return RedirectToAction("Index", "Pagos");
                }
                else
                {
                    ViewBag.Mensaje = "Datos incorrectos";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Incorrecto";
            }
            return View();
        }

        public IActionResult VerPerfil()
        {
            int usuarioId = (int)HttpContext.Session.GetInt32("Id");
            Usuario usuario = _sistema.BuscarUsuarioPorID(usuarioId);
            ViewBag.Usuario = usuario;
            ViewBag.NombreUsuario = usuario.Nombre;
            ViewBag.ApellidoUsuario = usuario.Apellido;
            ViewBag.EmailUsuario = usuario.Email;
            ViewBag.RolUsuario = usuario.Rol;
            ViewBag.FechaIncorporacionUsuario = usuario.FechaIncorporacion;
            ViewBag.EquipoUsuario = usuario.Equipo.Nombre;
            ViewBag.TotalGastadoUsuario = _sistema.CalcularGastoMesActual(usuario);
            _sistema.OrdenarUsuariosXMail();

            return View(_sistema.Usuarios);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}