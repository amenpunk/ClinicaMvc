using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//mierdas de mas
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;


namespace Clinica.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    public class PacienteApiController : ControllerBase
    {
        private readonly clinicaContext _context;

        public PacienteApiController(clinicaContext context){
            _context = context; 
        }

        [HttpGet]
        public async Task<IEnumerable<Paciente>> GetPaciente(){
            var result = await _context.Paciente.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id){
            var paciente = await _context.Paciente.FindAsync(id);

            if(paciente == null){
                return NotFound();
            }
        
            return paciente;
        }


    }
}