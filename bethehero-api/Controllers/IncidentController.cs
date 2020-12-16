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
    [Route("v1/incidents")]
    public class IncidentController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Incident>>> Get([FromServices] DataContext context)
        {
            var incidents = await context.Incident
            .Include(x => x.Ong)
            .ToListAsync();
            return incidents;
        }


        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Incident>> Post(
            [FromServices] DataContext context, [FromBody] Incident model, [FromHeader] int authorization)
        {
            if (ModelState.IsValid)
            {

                if (authorization > 0)
                {
                    model.OngId = authorization;
                    context.Incident.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else return BadRequest(ModelState);


            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteById(
            [FromServices] DataContext context,
            [FromHeader] int authorization,
            int id)
        {
            var incident = await context.Incident
            .FindAsync(id);

            if (incident.OngId != authorization)
            {
                return Unauthorized();
            }

            if (incident == null)
            {
                return NotFound();
            }

            context.Incident.Remove(incident);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}