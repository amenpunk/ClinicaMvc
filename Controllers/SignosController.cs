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
    public class SignosController : Controller
    {
        private readonly clinicaContext _context;

        public SignosController(clinicaContext context)
        {
            _context = context;
        }

        // GET: Signos
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.Signos.Include(s => s.IdConsultaNavigation).Include(s => s.IdEnfermeraNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: Signos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signos = await _context.Signos
                .Include(s => s.IdConsultaNavigation)
                .Include(s => s.IdEnfermeraNavigation)
                .FirstOrDefaultAsync(m => m.IdMedicion == id);
            if (signos == null)
            {
                return NotFound();
            }

            return View(signos);
        }

        // GET: Signos/Create
        public IActionResult Create()
        {
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta");
            ViewData["IdEnfermera"] = new SelectList(_context.Enfermera, "IdEnfermera", "IdEnfermera");
            return View();
        }

        // POST: Signos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicion,Estatura,Peso,Temp,Pulso,PresionArt,FrecCardiaca,FrecRespiratoria,IdEnfermera,Fecha,IdConsulta")] Signos signos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", signos.IdConsulta);
            ViewData["IdEnfermera"] = new SelectList(_context.Enfermera, "IdEnfermera", "IdEnfermera", signos.IdEnfermera);
            return View(signos);
        }

        // GET: Signos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signos = await _context.Signos.FindAsync(id);
            if (signos == null)
            {
                return NotFound();
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", signos.IdConsulta);
            ViewData["IdEnfermera"] = new SelectList(_context.Enfermera, "IdEnfermera", "IdEnfermera", signos.IdEnfermera);
            return View(signos);
        }

        // POST: Signos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicion,Estatura,Peso,Temp,Pulso,PresionArt,FrecCardiaca,FrecRespiratoria,IdEnfermera,Fecha,IdConsulta")] Signos signos)
        {
            if (id != signos.IdMedicion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignosExists(signos.IdMedicion))
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
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", signos.IdConsulta);
            ViewData["IdEnfermera"] = new SelectList(_context.Enfermera, "IdEnfermera", "IdEnfermera", signos.IdEnfermera);
            return View(signos);
        }

        // GET: Signos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signos = await _context.Signos
                .Include(s => s.IdConsultaNavigation)
                .Include(s => s.IdEnfermeraNavigation)
                .FirstOrDefaultAsync(m => m.IdMedicion == id);
            if (signos == null)
            {
                return NotFound();
            }

            return View(signos);
        }

        // POST: Signos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signos = await _context.Signos.FindAsync(id);
            _context.Signos.Remove(signos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignosExists(int id)
        {
            return _context.Signos.Any(e => e.IdMedicion == id);
        }
    }
}
