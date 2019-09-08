using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Enfermera
    {
        public Enfermera()
        {
            Signos = new HashSet<Signos>();
        }

        public int IdEnfermera { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Signos> Signos { get; set; }
    }
}
