using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using bethehero_api.Data;
using bethehero_api.Models;

namespace bethehero_api.Controllers
{
    [ApiController]
    [Route("v1/ongs")]
    public class OngController: ControllerBase
    {
       [HttpGet]
       [Route("")]

       public async Task<ActionResult<List<Ong>>> Get([FromServices] DataContext context)
       {
           var ongs = await context.Ong.ToListAsync();
           return ongs;
       } 
    }
}