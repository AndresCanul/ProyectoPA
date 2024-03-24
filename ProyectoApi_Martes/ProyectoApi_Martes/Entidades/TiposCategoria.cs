using ProyectoApi_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_Martes.Entidades
{
    public class TiposCategoria
    {
        public int IdCategoria { get; set; }

        public string NombreCategoria { get; set; }
    }

    public class ConfirmacionTiposCategoria
    {
        public int Codigo { get; set; }

        public string Detalle { get; set; }

        public List<ConsultarTiposCategoria_Result> Datos { get; set; }

        public ConsultarTiposCategoria_Result Dato { get; set; }
    }

}