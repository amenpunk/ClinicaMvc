using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFac = new HashSet<DetalleFac>();
        }

        public int NumFactura { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdExpediente { get; set; }

        public virtual Expediente IdExpedienteNavigation { get; set; }
        public virtual ICollection<DetalleFac> DetalleFac { get; set; }
    }
}
