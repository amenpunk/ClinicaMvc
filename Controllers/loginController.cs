using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Clinica.Controllers
{
    public class loginController : Controller
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
