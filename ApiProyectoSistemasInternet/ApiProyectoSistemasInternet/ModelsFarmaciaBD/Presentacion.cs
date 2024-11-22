using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Presentacion
    {
        public int IdPresentacion { get; set; }
        public string? Nombre { get; set; }
        public bool? EstadoPresentacion { get; set; }
    }
}
