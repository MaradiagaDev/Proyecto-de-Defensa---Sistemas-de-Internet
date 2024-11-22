using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class DevolucionCompra
    {
        public int IdDevolucionCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MotivoDevolucion { get; set; } = null!;
        public int Ndevolucion { get; set; }
        public int IdCompra { get; set; }
    }
}
