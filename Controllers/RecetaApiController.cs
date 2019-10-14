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
    public class RecetaApiController : ControllerBase
    {
        private readonly clinicaContext _context;
 

        public RecetaApiController(clinicaContext context){
            _context = context; 
        }

        
        [HttpGet]
        public async Task<IEnumerable<Receta>> GetReceta(){

            var result = await _context.Receta.ToListAsync();
            return result;

        }
        
        [HttpGet("{id}")]
        public IActionResult GetReceta(int id){
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.Receta.Where(p => p.IdConsulta == id).ToList();

            if(exp == null){
                return NotFound();
            }
        
            return Ok(exp);
        }

        [HttpPost]
        public async Task<ActionResult<Receta>> PostOrdenLab(Receta exp){
            _context.Receta.Add(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetReceta", new { id = exp.IdConsulta}, exp);
            //return CreatedAtRoute("GetDocument",doc, null);
        }

    }
}
