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
    public class enfermeraController : Controller
    {
        private readonly clinicaContext _context;

        public enfermeraController(clinicaContext context)
        {
            _context = context;
        }

        // GET: enfermera
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enfermera.ToListAsync());
        }

        // GET: enfermera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermera
                .FirstOrDefaultAsync(m => m.IdEnfermera == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // GET: enfermera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: enfermera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnfermera,Nombre,Estado")] Enfermera enfermera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermera);
        }

        // GET: enfermera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermera.FindAsync(id);
            if (enfermera == null)
            {
                return NotFound();
            }
            return View(enfermera);
        }

        // POST: enfermera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEnfermera,Nombre,Estado")] Enfermera enfermera)
        {
            if (id != enfermera.IdEnfermera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeraExists(enfermera.IdEnfermera))
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
            return View(enfermera);
        }

        // GET: enfermera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermera = await _context.Enfermera
                .FirstOrDefaultAsync(m => m.IdEnfermera == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // POST: enfermera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enfermera = await _context.Enfermera.FindAsync(id);
            _context.Enfermera.Remove(enfermera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeraExists(int id)
        {
            return _context.Enfermera.Any(e => e.IdEnfermera == id);
        }
    }
}
