using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Controllers
{
    [Authorize]
    public class MantenimientoController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
          //  return "This is my default action...";
          return View();
        }

        
    }
}
