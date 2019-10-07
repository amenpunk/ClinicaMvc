using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Clinica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Controllers {
  public class loginController : Controller {

    // GET: /HelloWorld/
    private readonly clinicaContext _context;

    public loginController (clinicaContext context) {
      _context = context;
    }

    public IActionResult Index () {

      return View ();
    }

  }
}