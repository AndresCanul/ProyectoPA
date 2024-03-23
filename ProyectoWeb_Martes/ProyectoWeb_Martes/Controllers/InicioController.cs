using ProyectoWeb_Martes.Entidades;
using ProyectoWeb_Martes.Models;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    public class InicioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario entidad)
        {
            var respuesta = modelo.IniciarSesionUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                Session["NombreUsuario"] = respuesta.Dato.Nombre;
                Session["RolUsuario"] = respuesta.Dato.ConsecutivoRol;
                return RedirectToAction("PantallaPrincipal", "Inicio");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }                
        }

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
            var respuesta = modelo.RegistrarUsuario(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("IniciarSesion", "Inicio");
            else
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
        }

        [HttpGet]
        public ActionResult RecuperarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarAcceso(Usuario entidad)
        {
            var respuesta = modelo.RecuperarAccesoUsuario(entidad);

            if (respuesta.Codigo == 0)
                return RedirectToAction("IniciarSesion", "Inicio");
            else
                ViewBag.MsjPantalla = respuesta.Detalle;
            return View();
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult PantallaPrincipal()
        {
            return View();
        }

        [FiltroSeguridad]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}