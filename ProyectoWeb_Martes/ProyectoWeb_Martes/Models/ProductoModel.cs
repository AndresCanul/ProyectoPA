using ProyectoWeb_Martes.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;

namespace ProyectoWeb_Martes.Models
{
    public class ProductoModel
    {
        public string url = ConfigurationManager.AppSettings["urlWebApi"];

        public ConfirmacionProducto ConsultarProductos(bool MostrarTodos)
        {
            using (var client = new HttpClient())
            {
                url += "Producto/ConsultarProductos?MostrarTodos=" + MostrarTodos;
                var respuesta = client.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<ConfirmacionProducto>().Result;
                else
                    return null;
            }
        }
    }
}