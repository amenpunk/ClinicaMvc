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
    public class DiagnosticoApiController : ControllerBase {
        private readonly clinicaContext _context;

        public DiagnosticoApiController (clinicaContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Diagnostico>> GetDiagnostico () {

            var result = await _context.Diagnostico.ToListAsync ();
            return result;

        }

        [HttpGet ("{id}")]
        public IActionResult GetDiagnostico (int id) {
            //var exp = await _context.Expediente.FindAsync(id);

            //var exp = await _context.Expediente.Where(a => a.IdPaciente == id);
            var exp = _context.Diagnostico.Where (p => p.IdConsulta == id).ToList ();

            if (exp == null) {
                return NotFound ();
            }

            return Ok (exp);
        }

        [HttpPost]
        public async Task<ActionResult<Diagnostico>> PostDiagnostico (Diagnostico exp) {
            _context.Diagnostico.Add (exp);
            await _context.SaveChangesAsync ();
            return CreatedAtAction ("GetDiagnostico", new { id = exp.IdDiagnostico }, exp);
            //return CreatedAtRoute("GetDocument",doc, null);
        }

    }
}