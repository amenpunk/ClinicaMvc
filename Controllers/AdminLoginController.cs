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
    public class AdminLoginController : Controller
    {
        private readonly clinicaContext _context;

        public AdminLoginController(clinicaContext context)
        {
            _context = context;
        }

        // GET: AdminLogin
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdminLogin.ToListAsync());
        }

        // GET: AdminLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            return View(adminLogin);
        }

        // GET: AdminLogin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,NombreAdmin,Email,Pass,Rol")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminLogin);
        }

        // GET: AdminLogin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin.FindAsync(id);
            if (adminLogin == null)
            {
                return NotFound();
            }
            return View(adminLogin);
        }

        // POST: AdminLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,NombreAdmin,Email,Pass,Rol")] AdminLogin adminLogin)
        {
            if (id != adminLogin.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminLoginExists(adminLogin.IdAdmin))
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
            return View(adminLogin);
        }

        // GET: AdminLogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (adminLogin == null)
            {
                return NotFound();
            }

            return View(adminLogin);
        }

        // POST: AdminLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adminLogin = await _context.AdminLogin.FindAsync(id);
            _context.AdminLogin.Remove(adminLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminLoginExists(int id)
        {
            return _context.AdminLogin.Any(e => e.IdAdmin == id);
        }
    }
}
