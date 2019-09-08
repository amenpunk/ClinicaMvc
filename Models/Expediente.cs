using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Expediente
    {
        public Expediente()
        {
            Consulta = new HashSet<Consulta>();
            Factura = new HashSet<Factura>();
        }

        public int IdExpediente { get; set; }
        public DateTime? FechaGen { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
