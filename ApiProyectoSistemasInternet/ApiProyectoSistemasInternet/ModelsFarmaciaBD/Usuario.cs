using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
        public string Rol { get; set; } = null!;
        public int IdEmpleado { get; set; }
    }
}
