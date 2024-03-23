using ProyectoWeb_Martes.Entidades;
using ProyectoWeb_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb_Martes.Controllers
{
    [FiltroSeguridad]
    [FiltroAdmin]
    public class ProductoController : Controller
    {
        ProductoModel modelo = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var respuesta = modelo.ConsultarProductos(true);

            if (respuesta.Codigo == 0)
                return View(respuesta.Datos);
            else
            {
                ViewBag.MsjPantalla = respuesta.Detalle;
                return View(new List<Producto>());
            }
        }
    }
}
