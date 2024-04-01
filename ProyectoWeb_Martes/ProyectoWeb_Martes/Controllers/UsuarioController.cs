using ProyectoWeb_Martes.Entidades;
using ProyectoWeb_Martes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    [FiltroSeguridad]
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class UsuarioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();

        [HttpGet]
        public ActionResult ConsultarUsuarios()
        {
            var respuesta = modelo.ConsultarUsuarios(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Usuario>());
            }
        }

        [HttpGet]
        public ActionResult ActualizarUsuario(long id)
        {
            var resp = modelo.ConsultarUsuario(id);
            CargarRoles();
            return View(resp.Dato);
        }

        [HttpPost]
        public ActionResult ActualizarUsuario(Usuario entidad)
        {
            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }

            else
            {
                CargarRoles();
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarPerfil()
        {
            var resp = modelo.ConsultarPerfil();
            return View(resp.Dato);
        }

        [HttpPost]
        public ActionResult ActualizarPerfil(Usuario entidad)
        {
            var respuesta = modelo.ActualizarUsuario(entidad);

            if (respuesta.Codigo == 0)
            {
                Session["NombreUsuario"] = entidad.Nombre;
                return RedirectToAction("ActualizarPerfil", "Usuario");
            }

            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeshabilitarUsuario(long id)
        {
            var respuesta = modelo.DeshabilitarUsuario(id);

            if (respuesta.Codigo == 0)
            {
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }

        private void CargarRoles()
        {
            var respuesta = modelo.ConsultarRoles();
            var roles = new List<SelectListItem>();

            roles.Add(new SelectListItem { Text = "Seleccione...", Value = "" });
            foreach (var item in respuesta.Datos)
                roles.Add(new SelectListItem { Text = item.NombreRol, Value = item.ConsecutivoRol.ToString() });

            ViewBag.Roles = roles;
        }
    }
}