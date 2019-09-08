using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Cita
    {
        public int IdCita { get; set; }
        public int? IdPaciente { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
