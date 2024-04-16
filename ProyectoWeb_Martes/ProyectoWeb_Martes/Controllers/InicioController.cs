using ProyectoWeb_Martes.Entidades;
using ProyectoWeb_Martes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class InicioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();
        ProductoModel productoModel = new ProductoModel();
        CarritoModel carritoModel = new CarritoModel();

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
                Session["Consecutivo"] = respuesta.Dato.Consecutivo;
                Session["NombreUsuario"] = respuesta.Dato.Nombre;
                Session["RolUsuario"] = respuesta.Dato.ConsecutivoRol;
                Session["NombreRol"] = respuesta.Dato.NombreRol;
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
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
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
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View();
            }
        }


        [FiltroSeguridad]
        [HttpGet]
        public ActionResult PantallaPrincipal()
        {
            var datos = carritoModel.ConsultarCarrito(long.Parse(Session["Consecutivo"].ToString()));

            if (datos.Codigo == 0)
            {
                Session["Cantidad"] = datos.Datos.AsEnumerable().Sum(x => x.Cantidad);
                Session["SubTotal"] = datos.Datos.AsEnumerable().Sum(x => x.SubTotal);
                Session["Total"] = datos.Datos.AsEnumerable().Sum(x => x.Total);
            }
            else
            {
                Session["Cantidad"] = "0";
                Session["SubTotal"] = "0";
                Session["Total"] = "0";
            }

            var respuesta = productoModel.ConsultarProductos(false);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Producto>());
            }
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