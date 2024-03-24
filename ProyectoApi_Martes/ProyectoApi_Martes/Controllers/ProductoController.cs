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

        [HttpGet]
        [Route("Producto/ConsultarProducto")]
        public ConfirmacionProducto ConsultarProducto(long Consecutivo)
        {
            var respuesta = new ConfirmacionProducto();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var dato = db.ConsultarProducto(Consecutivo).FirstOrDefault();

                    if (dato != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = dato;
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

        [HttpPost]
        [Route("Producto/RegistrarProducto")]
        public Confirmacion RegistrarProducto(Producto entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.RegistrarProducto(entidad.NombreProducto, entidad.Precio, entidad.Inventario, entidad.IdCategoria).FirstOrDefault();

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.ConsecutivoGenerado = resp.Value;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su informacion ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

        [HttpPut]
        [Route("Producto/ActualizarProducto")]
        public Confirmacion ActualizarProducto(Producto entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.ActualizarProducto(entidad.Consecutivo, entidad.NombreProducto, entidad.Precio, entidad.Inventario, entidad.IdCategoria);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su informacion ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

        [HttpPut]
        [Route("Producto/ActualizarImagenProducto")]
        public Confirmacion ActualizarImagenProducto(Producto entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.ActualizarImagenProducto(entidad.Consecutivo, entidad.RutaImagen);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su informacion ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

        [HttpGet]
        [Route("Producto/ConsultarTiposCategoria")]
        public ConfirmacionTiposCategoria ConsultarTiposCategoria()
        {
            var respuesta = new ConfirmacionTiposCategoria();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarTiposCategoria().ToList();

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

        [HttpDelete]
        [Route("Producto/DeshabilitarProducto")]
        public Confirmacion DeshabilitarProducto(long Consecutivo)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.DeshabilitarProducto(Consecutivo);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "Su informacion ya se encuentra registrada";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

    }
}
