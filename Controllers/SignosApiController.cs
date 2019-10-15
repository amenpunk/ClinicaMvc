using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//mierdas de mas
using System.Collections.Generic;
using System.Linq;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Controllers {

    [Authorize]
    [Route ("api/[controller]")]
    public class SignosApiController : ControllerBase {
        private readonly clinicaContext _context;

        public SignosApiController (clinicaContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Signos>> GetSignos () {

            var result = await _context.Signos.ToListAsync ();
            return result;

        }

        [HttpGet ("{id}")]
        public IActionResult GetSignos (int id) {
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.Signos.Where (p => p.IdConsulta == id).ToList ();

            if (exp == null) {
                return NotFound ();
            }

            return Ok (exp);
        }

        [HttpPost]
        public async Task<ActionResult<Signos>> PostSignos (Signos exp) {
            _context.Update(exp);
            await _context.SaveChangesAsync();
            return CreatedAtAction ("GetSignos", new { id = exp.IdMedicion }, exp);
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> PutSignos (int id, Signos signos) {
            if (id != signos.IdMedicion) {
                return BadRequest ();
            }
            _context.Entry (signos).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync ();
            } catch (DbUpdateConcurrencyException) {
                if (!SignosExists (id)) {
                    return NotFound ();
                } else {
                    throw;
                }
            }
            return NoContent ();
        }

        private bool SignosExists (int id) {
            return _context.Signos.Any (e => e.IdMedicion == id);
        }

    }
}