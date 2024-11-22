using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class DevolucionVentum
    {
        public int IdDevolucionVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string MotivoDevolucion { get; set; } = null!;
        public int Ndevolucion { get; set; }
        public int Nrecibo { get; set; }
    }
}
