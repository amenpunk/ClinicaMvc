using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View ();
        }
        
    }
}

