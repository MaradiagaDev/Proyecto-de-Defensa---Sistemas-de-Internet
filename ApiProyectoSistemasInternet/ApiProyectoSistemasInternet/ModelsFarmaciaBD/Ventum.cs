using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Ventum
    {
        public int IdVenta { get; set; }
        public decimal Monto { get; set; }
        public int Nrecibo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
    }
}
