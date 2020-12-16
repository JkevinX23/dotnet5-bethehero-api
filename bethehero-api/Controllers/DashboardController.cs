using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bethehero_api.Data;
using bethehero_api.Models;

namespace bethehero_api.Controllers
{
    [ApiController]
    [Route("v1/dashboard")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Ong>>> Get([FromServices] DataContext context)
        {
            var ongs = await context.Ong
            .ToListAsync();
            return ongs;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] DataContext context,
            int id)
        {
            var ong = await context.Ong
            .FindAsync(id);

            if (ong == null)
            {
                return NotFound();
            }

            context.Ong.Remove(ong);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update(
            [FromServices] DataContext context,
            [FromBody] Ong model)
        {
            context.Entry(model).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();

        }
    }
}