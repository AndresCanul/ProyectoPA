using ProyectoWeb_Martes.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace ProyectoWeb_Martes.Models
{
    public class UsuarioModel
    {
        public string url = ConfigurationManager.AppSettings["urlWebApi"];

        public ConfirmacionUsuario ConsultarUsuarios(bool MostrarTodos)
        {
            using (var client = new HttpClient())
            {
                long Consecutivo = long.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarUsuarios?Consecutivo=" + Consecutivo + "&MostrarTodos=" + MostrarTodos;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuario ConsultarUsuario(long Consecutivo)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarUsuario?Consecutivo=" + Consecutivo;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuario ConsultarPerfil()
        {
            using (var client = new HttpClient())
            {
                long Consecutivo = long.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarPerfil?Consecutivo=" + Consecutivo;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                else
                    return null;
            }
        }

        public Confirmacion RegistrarUsuario(Usuario entidad)
        {
            // LLamar al API
            using (var client = new HttpClient())
            {
                url += "Inicio/RegistrarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
               else
                    return null;
            }
        }

        public Confirmacion ActualizarUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ActualizarUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public Confirmacion ActualizarPerfil(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                entidad.Consecutivo = long.Parse(HttpContext.Current.Session["Consecutivo"].ToString());
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ActualizarPerfil";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PutAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuario IniciarSesionUsuario(Usuario entidad)
        {
            using (var client = new HttpClient())
            {
                url += "Inicio/IniciarSesionUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                else
                   return null;
            }
        }

        public Confirmacion DeshabilitarUsuario(long Consecutivo)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/DeshabilitarUsuario?Consecutivo=" + Consecutivo;
                var respuesta = client.DeleteAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public Confirmacion RecuperarAccesoUsuario(Usuario entidad)
        {
            // LLamar al API
            using (var client = new HttpClient())
            {
                url += "Inicio/RecuperarAccesoUsuario";
                JsonContent jsonEntidad = JsonContent.Create(entidad);
                var respuesta = client.PostAsync(url, jsonEntidad).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Confirmacion>().Result;
                else
                    return null;
            }
        }

        public ConfirmacionUsuario ConsultarRoles()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlWebApi"] + "Usuario/ConsultarRoles";
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionUsuario>().Result;
                else
                    return null;
            }
        }
    }
}