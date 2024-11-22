using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Recibo
    {
        public int Nrecibo { get; set; }
        public decimal CostoProducto { get; set; }
        public int IdTransaccion { get; set; }
    }
}
