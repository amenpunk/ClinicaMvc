using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Clinica.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers {
    public class AdminLoginController : Controller {
        private readonly clinicaContext _context;

        public AdminLoginController (clinicaContext context) {
            _context = context;
        }

        // GET: AdminLogin
        public async Task<IActionResult> Index () {
            return View (await _context.AdminLogin.ToListAsync ());
        }

        // GET: AdminLogin/Details/5
        public async Task<IActionResult> Details (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync (m => m.IdAdmin == id);
            if (adminLogin == null) {
                return NotFound ();
            }

            return View (adminLogin);
        }

        // GET: AdminLogin/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: AdminLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("IdAdmin,NombreAdmin,Email,Pass,Rol")] AdminLogin adminLogin) {
            if (ModelState.IsValid) {
                _context.Add (adminLogin);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (adminLogin);
        }

        // GET: AdminLogin/Edit/5
        public async Task<IActionResult> Edit (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var adminLogin = await _context.AdminLogin.FindAsync (id);
            if (adminLogin == null) {
                return NotFound ();
            }
            return View (adminLogin);
        }

        // POST: AdminLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind ("IdAdmin,NombreAdmin,Email,Pass,Rol")] AdminLogin adminLogin) {
            if (id != adminLogin.IdAdmin) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (adminLogin);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!AdminLoginExists (adminLogin.IdAdmin)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (adminLogin);
        }

        // GET: AdminLogin/Delete/5
        public async Task<IActionResult> Delete (int? id) {
            if (id == null) {
                return NotFound ();
            }

            var adminLogin = await _context.AdminLogin
                .FirstOrDefaultAsync (m => m.IdAdmin == id);
            if (adminLogin == null) {
                return NotFound ();
            }

            return View (adminLogin);
        }

        // POST: AdminLogin/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id) {
            var adminLogin = await _context.AdminLogin.FindAsync (id);
            _context.AdminLogin.Remove (adminLogin);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool AdminLoginExists (int id) {
            return _context.AdminLogin.Any (e => e.IdAdmin == id);
        }

        public async Task<IActionResult> logiar (string correo, string pass) {

            var myUser = _context.AdminLogin
                .FirstOrDefault (u => u.Email == correo &&
                    u.Pass == pass);

            if (myUser != null) //User was found
            {
                var claims = new List<Claim> ();
                //claims.Add (new Claim ("nombre", myUser.NombreAdmin.ToString ()));
                //claims.Add (new Claim ("correo", myUser.Email.ToString ()));
                claims.Add (new Claim (ClaimTypes.Role, myUser.Rol.ToString ()));
                claims.Add (new Claim (ClaimTypes.Name, myUser.NombreAdmin.ToString ()));

                //new Claim (ClaimTypes.Name, myUser.Email.ToString ()),
                //new Claim ("FullName", myUser.NombreAdmin.ToString ()),
                //new Claim (ClaimTypes.Role, myUser.Rol),

                //var authProperties = new AuthenticationProperties {
                //AllowRefresh = true,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = "/AdminLogin/Login"
                // The full path or absolute URI to be used as an http 
                // redirect response value.
                //                };

                //var claimsIdentity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var identity = new ClaimsIdentity (claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal (identity);
                //var props = new AuthenticationProperties();
                HttpContext.SignInAsync (CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait ();
                //await httpContext.SignInAsync(IdentityConstants.ApplicationScheme);
                await HttpContext.SignInAsync (CookieAuthenticationDefaults.AuthenticationScheme, principal);

                //HttpContext.Session.SetString ("user", myUser.NombreAdmin.ToString ());
                //HttpContext.Session.SetString ("rol", myUser.Rol.ToString ());
                //Session["user"] = myUser.NombreAdmin.ToString ();
                //Session["rol"] = myUser.Rol.ToString ();
                //Proceed with your login process...
            } else //User was not found
            {
                //Do something to let them know that their credentials were not valid
                return View ("~/Views/AdminLogin/login.cshtml");
            }
            //return View ("~/Views/Home/index.cshtml" );
            return View ("~/Views/home/index.cshtml");
        }

    }
}