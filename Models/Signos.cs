using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Signos
    {
        public int IdMedicion { get; set; }
        public double? Estatura { get; set; }
        public double? Peso { get; set; }
        public double? Temp { get; set; }
        public double? Pulso { get; set; }
        public double? PresionArt { get; set; }
        public double? FrecCardiaca { get; set; }
        public double? FrecRespiratoria { get; set; }
        public int? IdEnfermera { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdConsulta { get; set; }

        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual Enfermera IdEnfermeraNavigation { get; set; }
    }
}
