using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb_Martes.Entidades
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

        public List<TiposCategoria> Datos { get; set; }

        public TiposCategoria Dato { get; set; }
    }
}