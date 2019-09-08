using System;
using System.Collections.Generic;

namespace Clinica.Models
{
    public partial class AdminLogin
    {
        public AdminLogin()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int IdAdmin { get; set; }
        public string NombreAdmin { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int? Rol { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
