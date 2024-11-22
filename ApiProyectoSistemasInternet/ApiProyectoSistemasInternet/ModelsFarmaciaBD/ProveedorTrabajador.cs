using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class ProveedorTrabajador
    {
        public int IdTrabajador { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? DireccionTrabajador { get; set; }
        public string? Cargo { get; set; }
        public int? Edad { get; set; }
        public string? TelefonoTrabajador { get; set; }
        public string? Sexo { get; set; }
        public int IdProveedor { get; set; }
    }
}
