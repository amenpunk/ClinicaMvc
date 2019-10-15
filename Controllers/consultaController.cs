using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{

    [Authorize]
    public class consultaController : Controller
    {
        private readonly clinicaContext _context;

        public consultaController(clinicaContext context)
        {
            _context = context;
        }

        // GET: consulta
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Consulta.Include(c => c.IdDoctorNavigation).Include(c => c.IdExpedienteNavigation);
            return View(await clinicaContext.ToListAsync());
        }
        
        public IActionResult Detalles(int id)
        {

            ViewData["ident"] = id;
            return View();
        }

        // GET: consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdExpedienteNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: consulta/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor");
            ViewData["IdExpediente"] = new SelectList(_context.Expediente, "IdExpediente", "IdExpediente");
            return View();
        }

        // POST: consulta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,IdDoctor,Asunto,MontoCaja,Fecha,TipoConsulta,IdExpediente,SeguroMedico,NombreCompania,PolizaSeguro,Relacion")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", consulta.IdDoctor);
            ViewData["IdExpediente"] = new SelectList(_context.Expediente, "IdExpediente", "IdExpediente", consulta.IdExpediente);
            return View(consulta);
        }

        // GET: consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", consulta.IdDoctor);
            ViewData["IdExpediente"] = new SelectList(_context.Expediente, "IdExpediente", "IdExpediente", consulta.IdExpediente);
            return View(consulta);
        }

        // POST: consulta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,IdDoctor,Asunto,MontoCaja,Fecha,TipoConsulta,IdExpediente,SeguroMedico,NombreCompania,PolizaSeguro,Relacion")] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.IdConsulta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctor, "IdDoctor", "IdDoctor", consulta.IdDoctor);
            ViewData["IdExpediente"] = new SelectList(_context.Expediente, "IdExpediente", "IdExpediente", consulta.IdExpediente);
            return View(consulta);
        }

        // GET: consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdExpedienteNavigation)
                .FirstOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consulta.FindAsync(id);
            _context.Consulta.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consulta.Any(e => e.IdConsulta == id);
        }
    }
}
