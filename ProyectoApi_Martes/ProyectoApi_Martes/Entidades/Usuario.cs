using ProyectoApi_Martes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoApi_Martes.Entidades
{
    public class Usuario
    {
        public string Identificacion { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public long ConsecutivoRol { get; set; }

        public string NombreRol { get; set; }
    }

    public class ConfirmacionUsuario
    {
        public int Codigo { get; set; }

        public string Detalle { get; set; }

        public List<IniciarSesionUsuario_Result> Datos { get; set; }

        public IniciarSesionUsuario_Result Dato { get; set; }
    }
}