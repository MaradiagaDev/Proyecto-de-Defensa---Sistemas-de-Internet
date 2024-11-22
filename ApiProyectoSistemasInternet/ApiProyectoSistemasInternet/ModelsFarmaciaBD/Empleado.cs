using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Cargo { get; set; } = null!;
        public string CodigoUsuario { get; set; } = null!;
        public int Edad { get; set; }
        public bool EstadoEmpleado { get; set; }
        public int NivelAcceso { get; set; }
        public string LoginUsuario { get; set; } = null!;
        public string PasswordUsuario { get; set; } = null!;
        public string? Telefono { get; set; }
        public int? IdPersona { get; set; }
    }
}
