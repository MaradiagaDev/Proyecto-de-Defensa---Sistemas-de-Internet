using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class TipoProducto
    {
        public int IdTipoProducto { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
    }
}
