using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//mierdas de mas
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;


namespace Clinica.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    public class CitaApiController : ControllerBase
    {
        private readonly clinicaContext _context;
 

        public CitaApiController(clinicaContext context){
            _context = context; 
        }

        
        [HttpGet]
        public async Task<IEnumerable<Cita>> GetCita(){

            var result = await _context.Cita.ToListAsync();
            return result;

        }


    }
}
