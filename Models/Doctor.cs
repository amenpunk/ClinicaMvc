using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdDoctor { get; set; }
        public string NoColegiado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
