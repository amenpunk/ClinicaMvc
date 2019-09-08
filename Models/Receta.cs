using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Receta
    {
        public Receta()
        {
            DesReceta = new HashSet<DesReceta>();
        }

        public int IdReceta { get; set; }
        public int? IdConsulta { get; set; }

        public virtual Consulta IdConsultaNavigation { get; set; }
        public virtual ICollection<DesReceta> DesReceta { get; set; }
    }
}
