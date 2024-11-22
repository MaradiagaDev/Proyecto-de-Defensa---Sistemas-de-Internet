using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Compra
    {
        public int IdCompra { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
        public int Nfactura { get; set; }
    }
}
