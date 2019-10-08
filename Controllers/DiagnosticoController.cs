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
    public class DiagnosticoController : Controller
    {
        private readonly clinicaContext _context;

        public DiagnosticoController(clinicaContext context)
        {
            _context = context;
        }

        // GET: Diagnostico
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Diagnostico.Include(d => d.IdConsultaNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Diagnostico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnostico
                .Include(d => d.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdDiagnostico == id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // GET: Diagnostico/Create
        public IActionResult Create()
        {
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta");
            return View();
        }

        // POST: Diagnostico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiagnostico,IdCie,IdConsulta")] Diagnostico diagnostico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diagnostico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", diagnostico.IdConsulta);
            return View(diagnostico);
        }

        // GET: Diagnostico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnostico.FindAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", diagnostico.IdConsulta);
            return View(diagnostico);
        }

        // POST: Diagnostico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiagnostico,IdCie,IdConsulta")] Diagnostico diagnostico)
        {
            if (id != diagnostico.IdDiagnostico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diagnostico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticoExists(diagnostico.IdDiagnostico))
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
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", diagnostico.IdConsulta);
            return View(diagnostico);
        }

        // GET: Diagnostico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnostico = await _context.Diagnostico
                .Include(d => d.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdDiagnostico == id);
            if (diagnostico == null)
            {
                return NotFound();
            }

            return View(diagnostico);
        }

        // POST: Diagnostico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnostico = await _context.Diagnostico.FindAsync(id);
            _context.Diagnostico.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosticoExists(int id)
        {
            return _context.Diagnostico.Any(e => e.IdDiagnostico == id);
        }
    }
}
