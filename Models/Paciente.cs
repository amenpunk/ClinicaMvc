using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
            Expediente = new HashSet<Expediente>();
        }

        public int IdPaciente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string ApellidoCasada { get; set; }
        public string Genero { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NoId { get; set; }
        public string TipoEncargado { get; set; }
        public string NombreEncargado { get; set; }
        public string NumeroTel { get; set; }
        public int? IdAdmin { get; set; }

        public virtual AdminLogin IdAdminNavigation { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Expediente> Expediente { get; set; }
    }
}
