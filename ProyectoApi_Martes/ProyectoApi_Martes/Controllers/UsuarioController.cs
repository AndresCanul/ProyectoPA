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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("Usuario/ConsultarUsuarios")]
        public ConfirmacionProducto ConsultarUsuarios(long Consecutivo, bool MostrarTodos)
        {
            var respuesta = new ConfirmacionProducto();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarUsuarios(Consecutivo, MostrarTodos).ToList();

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
        [Route("Usuario/ConsultarUsuario")]
        public ConfirmacionUsuario ConsultarUsuario(long Consecutivo)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var dato = db.ConsultarUsuario(Consecutivo).FirstOrDefault();

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

        [HttpGet]
        [Route("Usuario/ConsultarPerfil")]
        public ConfirmacionUsuario ConsultarPerfil(long Consecutivo)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var dato = db.ConsultarPerfil(Consecutivo).FirstOrDefault();

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

        [HttpPut]
        [Route("Usuario/ActualizarPerfil")]
        public Confirmacion ActualizarPerfil(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.ActualizarPerfil(entidad.Consecutivo, entidad.Clave, entidad.Nombre, entidad.CorreoElectronico);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El usuario no se pudo actualizar";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

        [HttpPut]
        [Route("Usuario/ActualizarUsuario")]
        public Confirmacion ActualizarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.ActualizarUsuario(entidad.Consecutivo, entidad.ConsecutivoRol, entidad.Nombre, entidad.CorreoElectronico);

                    if (resp > 0)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "El usuario no se pudo actualizar";
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error en la BD

                //Enviar el eror en al cliente
                respuesta.Codigo = -1;
                respuesta.Detalle = "Se presento un error en el sistema";
            }

            return respuesta;
            /*
            Ejemplo

            var context = new martes_dbEntities();
            context.Dispose();
            */
        }

        [HttpDelete]
        [Route("Usuario/DeshabilitarUsuario")]
        public Confirmacion DeshabilitarUsuario(long Consecutivo)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.DeshabilitarUsuario(Consecutivo);

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
                respuesta.Codigo = -1;
                respuesta.Detalle = "su informacion no se pudo registrar";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("Usuario/ConsultarRoles")]
        public ConfirmacionProducto ConsultarRoles()
        {
            var respuesta = new ConfirmacionProducto();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var datos = db.ConsultarRoles().ToList();

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
