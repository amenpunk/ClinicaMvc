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
    public class DetalleFacturaController : Controller
    {
        private readonly clinicaContext _context;

        public DetalleFacturaController(clinicaContext context)
        {
            _context = context;
        }

        // GET: DetalleFactura
        public async Task<IActionResult> Index()
        {
            var clinicaContext = _context.DetalleFac.Include(d => d.NumFacturaNavigation);
            return View(await clinicaContext.ToListAsync());
        }

        // GET: DetalleFactura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFac = await _context.DetalleFac
                .Include(d => d.NumFacturaNavigation)
                .FirstOrDefaultAsync(m => m.NumDetalle == id);
            if (detalleFac == null)
            {
                return NotFound();
            }

            return View(detalleFac);
        }

        // GET: DetalleFactura/Create
        public IActionResult Create()
        {
            ViewData["NumFactura"] = new SelectList(_context.Factura, "NumFactura", "NumFactura");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumDetalle,NumFactura,NombreConsulta,Cantidad,Precio")] DetalleFac detalleFac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NumFactura"] = new SelectList(_context.Factura, "NumFactura", "NumFactura", detalleFac.NumFactura);
            return View(detalleFac);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFac = await _context.DetalleFac.FindAsync(id);
            if (detalleFac == null)
            {
                return NotFound();
            }
            ViewData["NumFactura"] = new SelectList(_context.Factura, "NumFactura", "NumFactura", detalleFac.NumFactura);
            return View(detalleFac);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumDetalle,NumFactura,NombreConsulta,Cantidad,Precio")] DetalleFac detalleFac)
        {
            if (id != detalleFac.NumDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacExists(detalleFac.NumDetalle))
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
            ViewData["NumFactura"] = new SelectList(_context.Factura, "NumFactura", "NumFactura", detalleFac.NumFactura);
            return View(detalleFac);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFac = await _context.DetalleFac
                .Include(d => d.NumFacturaNavigation)
                .FirstOrDefaultAsync(m => m.NumDetalle == id);
            if (detalleFac == null)
            {
                return NotFound();
            }

            return View(detalleFac);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleFac = await _context.DetalleFac.FindAsync(id);
            _context.DetalleFac.Remove(detalleFac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacExists(int id)
        {
            return _context.DetalleFac.Any(e => e.NumDetalle == id);
        }
    }
}
