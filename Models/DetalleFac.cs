using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class DetalleFac
    {
        public int NumDetalle { get; set; }
        public int? NumFactura { get; set; }
        public string NombreConsulta { get; set; }
        public int? Cantidad { get; set; }
        public double? Precio { get; set; }

        public virtual Factura NumFacturaNavigation { get; set; }
    }
}
