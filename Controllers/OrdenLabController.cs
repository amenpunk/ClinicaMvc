using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Clinica.Models;

namespace Clinica.Controllers
{
    [Authorize]
    public class OrdenLabController : Controller
    {
        private readonly clinicaContext _context;

        public OrdenLabController(clinicaContext context)
        {
            _context = context;
        }

        // GET: OrdenLab
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.OrdenLab.Include(o => o.IdConsultaNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: OrdenLab/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenLab = await _context.OrdenLab
                .Include(o => o.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (ordenLab == null)
            {
                return NotFound();
            }

            return View(ordenLab);
        }

        // GET: OrdenLab/Create
        public IActionResult Create()
        {
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta");
            return View();
        }

        // POST: OrdenLab/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrden,NombreExamen,IdConsulta")] OrdenLab ordenLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", ordenLab.IdConsulta);
            return View(ordenLab);
        }

        // GET: OrdenLab/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenLab = await _context.OrdenLab.FindAsync(id);
            if (ordenLab == null)
            {
                return NotFound();
            }
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", ordenLab.IdConsulta);
            return View(ordenLab);
        }

        // POST: OrdenLab/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrden,NombreExamen,IdConsulta")] OrdenLab ordenLab)
        {
            if (id != ordenLab.IdOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenLabExists(ordenLab.IdOrden))
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
            ViewData["IdConsulta"] = new SelectList(_context.Consulta, "IdConsulta", "IdConsulta", ordenLab.IdConsulta);
            return View(ordenLab);
        }

        // GET: OrdenLab/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenLab = await _context.OrdenLab
                .Include(o => o.IdConsultaNavigation)
                .FirstOrDefaultAsync(m => m.IdOrden == id);
            if (ordenLab == null)
            {
                return NotFound();
            }

            return View(ordenLab);
        }

        // POST: OrdenLab/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenLab = await _context.OrdenLab.FindAsync(id);
            _context.OrdenLab.Remove(ordenLab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenLabExists(int id)
        {
            return _context.OrdenLab.Any(e => e.IdOrden == id);
        }
    }
}
