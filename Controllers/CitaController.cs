using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica
{
    [Authorize]
    public class CitaController : Controller
    {
        private readonly clinicaContext _context;

        public CitaController(clinicaContext context)
        {
            _context = context;
        }

        // GET: Cita
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Cita.Include(c => c.IdPacienteNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Cita/Create
        public IActionResult Create()
        {
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,IdPaciente,Estado,FechaInicio,FechaFinal")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.FindAsync(id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,IdPaciente,Estado,FechaInicio,FechaFinal")] Cita cita)
        {
            if (id != cita.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.IdCita))
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
            ViewData["IdPaciente"] = new SelectList(_context.Paciente, "IdPaciente", "IdPaciente", cita.IdPaciente);
            return View(cita);
        }

        // GET: Cita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita
                .Include(c => c.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.FindAsync(id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.IdCita == id);
        }
    }
}
