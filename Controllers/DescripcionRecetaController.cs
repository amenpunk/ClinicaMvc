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
    public class DescripcionRecetaController : Controller
    {
        private readonly clinicaContext _context;

        public DescripcionRecetaController(clinicaContext context)
        {
            _context = context;
        }

        // GET: DescripcionReceta
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.DesReceta.Include(d => d.IdRecetaNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: DescripcionReceta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desReceta = await _context.DesReceta
                .Include(d => d.IdRecetaNavigation)
                .FirstOrDefaultAsync(m => m.IdDescripcion == id);
            if (desReceta == null)
            {
                return NotFound();
            }

            return View(desReceta);
        }

        // GET: DescripcionReceta/Create
        public IActionResult Create()
        {
            ViewData["IdReceta"] = new SelectList(_context.Receta, "IdReceta", "IdReceta");
            return View();
        }

        // POST: DescripcionReceta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDescripcion,IdReceta,Medicamento,Cantidad,Dosis")] DesReceta desReceta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desReceta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReceta"] = new SelectList(_context.Receta, "IdReceta", "IdReceta", desReceta.IdReceta);
            return View(desReceta);
        }

        // GET: DescripcionReceta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desReceta = await _context.DesReceta.FindAsync(id);
            if (desReceta == null)
            {
                return NotFound();
            }
            ViewData["IdReceta"] = new SelectList(_context.Receta, "IdReceta", "IdReceta", desReceta.IdReceta);
            return View(desReceta);
        }

        // POST: DescripcionReceta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDescripcion,IdReceta,Medicamento,Cantidad,Dosis")] DesReceta desReceta)
        {
            if (id != desReceta.IdDescripcion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desReceta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesRecetaExists(desReceta.IdDescripcion))
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
            ViewData["IdReceta"] = new SelectList(_context.Receta, "IdReceta", "IdReceta", desReceta.IdReceta);
            return View(desReceta);
        }

        // GET: DescripcionReceta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desReceta = await _context.DesReceta
                .Include(d => d.IdRecetaNavigation)
                .FirstOrDefaultAsync(m => m.IdDescripcion == id);
            if (desReceta == null)
            {
                return NotFound();
            }

            return View(desReceta);
        }

        // POST: DescripcionReceta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var desReceta = await _context.DesReceta.FindAsync(id);
            _context.DesReceta.Remove(desReceta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesRecetaExists(int id)
        {
            return _context.DesReceta.Any(e => e.IdDescripcion == id);
        }
    }
}
