using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Proveedor
    {
        public int IdProveedor { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaUltimoPedido { get; set; }
        public string NombreCompania { get; set; } = null!;
        public int IdPersona { get; set; }
        public string? Telefono { get; set; }
    }
}
