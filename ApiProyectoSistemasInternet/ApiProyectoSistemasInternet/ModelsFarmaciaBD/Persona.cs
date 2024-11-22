using System;
using System.Collections.Generic;

namespace ApiProyectoSistemasInternet.ModelsFarmaciaBD
{
    public partial class Persona
    {
        public int IdPersona { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string Direccion { get; set; } = null!;
        public string? Correo { get; set; }
        public string Sexo { get; set; } = null!;
    }
}
