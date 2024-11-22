using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public string Concentracion { get; set; } = null!;
        public string? UnidadMedida { get; set; }
        public string DescripcionProducto { get; set; } = null!;
        public bool EstadoProducto { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdPresentacion { get; set; }
        public int IdRubro { get; set; }
        public int IdTipoProducto { get; set; }
        public decimal MargenGanancias { get; set; }
        public string NombreProducto { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int StockMedio { get; set; }
    }
}
