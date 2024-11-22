using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Transaccion
    {
        public int IdTransaccion { get; set; }
        public decimal? Descuento { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public string Tipo { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
