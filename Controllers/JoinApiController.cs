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
    public class JoinApiController : ControllerBase
    {
        private readonly clinicaContext _context;

        public JoinApiController(clinicaContext context){
            _context = context; 
        }

        /*         [HttpGet]
        public async Task<IEnumerable<Expediente>> GetExpediente(){
            var result = await _context.Expediente.ToListAsync();
            return result;
        }*/
        [HttpGet]
        public IActionResult GetJoin(){

            var resu = (from e in _context.Expediente
                 join p in _context.Paciente on e.IdPaciente equals p.IdPaciente
                 where e.Estado == null
                 select new {
                     nombre = p.PrimerNombre,
                     nombre2 = p.SegundoNombre,
                     apellido = p.PrimerApellido,
                     apellido2= p.SegundoApellido,
                     idexp = e.IdExpediente,
                     fechaexp = e.FechaGen
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



