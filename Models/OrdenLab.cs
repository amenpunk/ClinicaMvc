using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class OrdenLab
    {
        public int IdOrden { get; set; }
        public string NombreExamen { get; set; }
        public int? IdConsulta { get; set; }

        public virtual Consulta IdConsultaNavigation { get; set; }
    }
}
