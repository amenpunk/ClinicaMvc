
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
    public class ConsultaApiController : ControllerBase
    {
        private readonly clinicaContext _context;
 

        public ConsultaApiController(clinicaContext context){
            _context = context; 
        }

        
        [HttpGet]
        public async Task<IEnumerable<Consulta>> GetConsulta(){

            var result = await _context.Consulta.ToListAsync();
            return result;

        }
        
        [HttpGet("{id}")]
        public IActionResult GetConsulta(int id){

            var resu = (from c in _context.Consulta
                 join e in _context.Expediente on c.IdExpediente equals e.IdExpediente
                 join p in _context.Paciente on e.IdPaciente equals p.IdPaciente
                 where c.IdConsulta == id
                 select new {
                     id_con = c.IdConsulta,
                     monto = c.MontoCaja,
                     asunto = c.Asunto,
                     nombre = p.PrimerNombre,
                     nombre2 = p.SegundoNombre,
                     apellido = p.PrimerApellido,
                     apellido2= p.SegundoApellido,
                     idexp = e.IdExpediente,
                     fechaexp = e.FechaGen,
                 }).ToList();

            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            //var exp = _context.Consulta.Where(p => p.IdConsulta == id).ToList();

            if(resu == null){
                return NotFound();
            }
        
            return Ok(resu);
        }

    }
}
