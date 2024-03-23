using ProyectoApi_Martes.Entidades;
using ProyectoApi_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoApi_Martes.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        [Route("Producto/ConsultarProductos")]
        public ConfirmacionProducto ConsultarProductos(bool MostrarTodos)
        {
            var respuesta = new ConfirmacionProducto();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarProductos(MostrarTodos).ToList();

                    if (datos.Count > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Datos = datos;
                        
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se encontraron resultados";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
        }

    }
}
