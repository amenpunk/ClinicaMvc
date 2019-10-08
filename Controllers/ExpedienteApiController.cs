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
    public class ExpedienteApiController : ControllerBase
    {
        private readonly clinicaContext _context;

        public ExpedienteApiController(clinicaContext context){
            _context = context; 
        }

        [HttpGet]
        public async Task<IEnumerable<Expediente>> GetExpediente(){
            var result = await _context.Expediente.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetExpediente(int id){
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.Expediente.Where(p => p.IdPaciente == id).ToList();

            if(exp == null){
                return NotFound();
            }
        
            return Ok(exp);
        }


    }
}