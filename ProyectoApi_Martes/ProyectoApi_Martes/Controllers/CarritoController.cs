using ProyectoApi_Martes.Entidades;
using ProyectoApi_Martes.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace ProyectoApi_Martes.Controllers
{
    public class CarritoController : ApiController
    {
        [HttpPost]
        [Route("Carrito/AgregarCarrito")]
        public Confirmacion AgregarCarrito(Carrito entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var resp = db.AgregarCarrito(entidad.ConsecutivoUsuario, entidad.ConsecutivoProducto, entidad.Cantidad);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo agregar la información al carrito";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpDelete]
        [Route("Carrito/EliminarCarrito")]
        public Confirmacion EliminarCarrito(long ConsecutivoCarrito)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var resp = db.EliminarCarrito(ConsecutivoCarrito);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo eliminar la información del carrito";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Carrito/ConsultarCarrito")]
        public ConfirmacionCarrito ConsultarCarrito(long ConsecutivoUsuario)
        {
            var respuesta = new ConfirmacionCarrito();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarCarrito(ConsecutivoUsuario).ToList();

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
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpPost]
        [Route("Carrito/PagarCarrito")]
        public Confirmacion PagarCarrito(Carrito entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var resp = db.PagarCarrito(entidad.ConsecutivoUsuario);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo pagar su carrito";
                    }
                }
            }
            catch (Exception)
            {
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Carrito/ConsultarFacturas")]
        public ConfirmacionCarrito ConsultarFacturas(long ConsecutivoUsuario)
        {
            var respuesta = new ConfirmacionCarrito();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarFacturas(ConsecutivoUsuario).ToList();

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
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Carrito/ConsultarDetalleFacturas")]
        public ConfirmacionCarrito ConsultarDetalleFacturas(long ConsecutivoMaestro)
        {
            var respuesta = new ConfirmacionCarrito();

            try
            {
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarDetalleFacturas(ConsecutivoMaestro).ToList();

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
                respuesta.Detalle = "Se presentó un error en el sistema";
            }

            return respuesta;
        }
    }
}
