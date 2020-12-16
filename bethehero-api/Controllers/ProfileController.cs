using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bethehero_api.Data;
using bethehero_api.Models;
using System.Linq;

namespace bethehero_api.Controllers
{
    [ApiController]
    [Route("v1/profile")]
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Incident>>> Profile([FromServices] DataContext context, [FromHeader] int authorization, int id)
        {
            if(id > 0 )
            {
                var incidents = await context.Incident
                .Include(x => x.Ong)
                .AsNoTracking()
                .Where(x => x.OngId == id)
                .ToListAsync();
                return incidents;
            }
           return BadRequest(ModelState);
        }
    }
}