using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class DesReceta
    {
        public int IdDescripcion { get; set; }
        public int? IdReceta { get; set; }
        public string Medicamento { get; set; }
        public double? Cantidad { get; set; }
        public string Dosis { get; set; }

        public virtual Receta IdRecetaNavigation { get; set; }
    }
}
