using ProyectoWeb_Martes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    public class InicioController : Controller
    {
        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Usuario entidad)
        {
            return RedirectToAction("PantallaPrincipal", "Inicio");
        }

        [HttpGet]
        public ActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuario entidad)
        {
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
            return View();
        }

        [HttpGet]
        public ActionResult PantallaPrincipal()
        {
            return View();
        }
    }
}