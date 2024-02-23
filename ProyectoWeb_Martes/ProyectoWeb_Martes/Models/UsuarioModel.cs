using ProyectoWeb_Martes.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProyectoWeb_Martes.Models
{
    public class UsuarioModel
    {
        public string url = ConfigurationManager.AppSettings["urlWebApi"];

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
    }
}