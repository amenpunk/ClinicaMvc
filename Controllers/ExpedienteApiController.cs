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
        public  async Task<ActionResult<IEnumerable<Expediente>>>  GetExpediente(int id,int estado){
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);

            var exp = await _context.Expediente.Where(p => p.IdPaciente == id && p.Estado == estado).ToListAsync();
            
            if(estado == 3 ){
                exp = await _context.Expediente.Where(p => p.IdPaciente == id).ToListAsync();
            }

       
            //if(exp == null){
            //    return NotFound();
            //}
        
            //return Ok(exp);
            return(exp);
        }

        [HttpPost]
        public async Task<ActionResult<Expediente>> PostExpediente(Expediente exp){
            _context.Expediente.Add(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetExpediente", new { id = exp.IdExpediente}, exp);
            //return CreatedAtRoute("GetDocument",doc, null);
        }

    }
}
