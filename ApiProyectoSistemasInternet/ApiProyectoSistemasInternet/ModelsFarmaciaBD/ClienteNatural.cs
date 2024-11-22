using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class ClienteNatural
    {
        public int IdCliente { get; set; }
        public int Edad { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdPersona { get; set; }
        public string? Telefono { get; set; }
    }
}
