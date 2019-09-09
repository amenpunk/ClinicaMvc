using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;

namespace Clinica.Controllers
{
    public class expedienteController : Controller
    {
        private readonly clinicaContext _context;

        public expedienteController(clinicaContext context)
        {
            _context = context;
        }

        // GET: expediente
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Expediente.Include(e => e.IdPacienteNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: expediente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExpediente == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // GET: expediente/Create
        public IActionResult Create()
        {
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: expediente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExpediente,FechaGen,IdPaciente")] Expediente expediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", expediente.IdPaciente);
            return View(expediente);
        }

        // GET: expediente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", expediente.IdPaciente);
            return View(expediente);
        }

        // POST: expediente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExpediente,FechaGen,IdPaciente")] Expediente expediente)
        {
            if (id != expediente.IdExpediente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedienteExists(expediente.IdExpediente))
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
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", expediente.IdPaciente);
            return View(expediente);
        }

        // GET: expediente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expediente = await _context.Expediente
                .Include(e => e.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdExpediente == id);
            if (expediente == null)
            {
                return NotFound();
            }

            return View(expediente);
        }

        // POST: expediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expediente = await _context.Expediente.FindAsync(id);
            _context.Expediente.Remove(expediente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expediente.Any(e => e.IdExpediente == id);
        }
    }
}
