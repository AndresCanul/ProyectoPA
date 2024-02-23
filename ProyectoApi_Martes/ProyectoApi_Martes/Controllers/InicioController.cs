using ProyectoApi_Martes.Entidades;
using ProyectoApi_Martes.Models;
using ProyectoWeb_Martes.Entidades;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web.Http;

namespace ProyectoApi_Martes.Controllers
{
    public class InicioController : ApiController
    {
        [HttpPost]
        [Route("Inicio/RegistrarUsuario")]
        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var resp = db.RegistrarUsuario(entidad.Identificacion, entidad.Clave, entidad.Nombre, entidad.CorreoElectronico);

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

        [HttpPost]
        [Route("Inicio/IniciarSesionUsuario")]
        public ConfirmacionUsuario IniciarSesionUsuario(Usuario entidad)
        {
            var respuesta = new ConfirmacionUsuario();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var dato = db.IniciarSesionUsuario(entidad.Identificacion, entidad.Clave).FirstOrDefault();

                    if (dato != null)
                    {
                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                        respuesta.Dato = dato;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su informacion de ingreso";
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
        [Route("Inicio/RecuperarAccesoUsuario")]
        public Confirmacion RecuperarAccesoUsuario(Usuario entidad)
        {
            var respuesta = new Confirmacion();

            try
            {
                //Llamar a la base de datos
                using (var db = new martes_dbEntities())
                {
                    var dato = db.RecuperarAccesoUsuario(entidad.Identificacion, entidad.CorreoElectronico).FirstOrDefault();

                    if (dato != null)
                    {
                        // Mandar un correo
                        EnviarCorreo(dato.CorreoElectronico, "Acceso Temporal", dato.Clave);

                        respuesta.Codigo = 0;
                        respuesta.Detalle = string.Empty;
                    }
                    else
                    {
                        respuesta.Codigo = -1;
                        respuesta.Detalle = "No se pudo validar su informacion";
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

        private void EnviarCorreo(string destino, string asunto, string contenido)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["cuentaCorreo"]);
            message.To.Add(new MailAddress(destino));
            message.Subject = asunto;
            message.Body = contenido;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cuentaCorreo"], 
                                                                  ConfigurationManager.AppSettings["claveCorreo"]);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
