using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Consulta
    {
        public Consulta()
        {
            Diagnostico = new HashSet<Diagnostico>();
            OrdenLab = new HashSet<OrdenLab>();
            Receta = new HashSet<Receta>();
            Signos = new HashSet<Signos>();
        }

        public int IdConsulta { get; set; }
        public int? IdDoctor { get; set; }
        public string Asunto { get; set; }
        public double? MontoCaja { get; set; }
        public DateTime? Fecha { get; set; }
        public string TipoConsulta { get; set; }
        public int? IdExpediente { get; set; }
        public int? SeguroMedico { get; set; }
        public string NombreCompania { get; set; }
        public string PolizaSeguro { get; set; }
        public string Relacion { get; set; }

        public virtual Doctor IdDoctorNavigation { get; set; }
        public virtual Expediente IdExpedienteNavigation { get; set; }
        public virtual ICollection<Diagnostico> Diagnostico { get; set; }
        public virtual ICollection<OrdenLab> OrdenLab { get; set; }
        public virtual ICollection<Receta> Receta { get; set; }
        public virtual ICollection<Signos> Signos { get; set; }
    }
}
