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
    public class OrdenLabApiController : ControllerBase
    {
        private readonly clinicaContext _context;
 

        public OrdenLabApiController(clinicaContext context){
            _context = context; 
        }

        
        [HttpGet]
        public async Task<IEnumerable<OrdenLab>> GetOrdenLab(){

            var result = await _context.OrdenLab.ToListAsync();
            return result;

        }
        
        [HttpGet("{id}")]
        public IActionResult GetOrdenLab(int id){
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.OrdenLab.Where(p => p.IdConsulta == id).ToList();

            if(exp == null){
                return NotFound();
            }
        
            return Ok(exp);
        }

        [HttpPost]
        public async Task<ActionResult<OrdenLab>> PostOrdenLab(OrdenLab exp){
            _context.OrdenLab.Add(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOrdenLab", new { id = exp.IdOrden}, exp);
            //return CreatedAtRoute("GetDocument",doc, null);
        }

    }
}
