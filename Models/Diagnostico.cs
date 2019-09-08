using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public string IdCie { get; set; }
        public int? IdConsulta { get; set; }

        public virtual Consulta IdConsultaNavigation { get; set; }
    }
}
