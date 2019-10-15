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
    public class DescripcionRecetaApiController : ControllerBase
    {
        private readonly clinicaContext _context;
 

        public DescripcionRecetaApiController(clinicaContext context){
            _context = context; 
        }

        
        [HttpGet]
        public async Task<IEnumerable<DesReceta>> GetDescripcionReceta(){

            var result = await _context.DesReceta.ToListAsync();
            return result;

        }
        
        [HttpGet("{id}")]
        public IActionResult GetDescripcionReceta(int id){
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.DesReceta.Where(p => p.IdReceta == id).ToList();

            if(exp == null){
                return NotFound();
            }
        
            return Ok(exp);
        }

        [HttpPost]
        public async Task<ActionResult<DesReceta>> PostDescripcionReceta(DesReceta exp){
            _context.DesReceta.Add(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDescripcionReceta", new { id = exp.IdDescripcion}, exp);
            //return CreatedAtRoute("GetDocument",doc, null);
        }

    }
}
