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
    [Route("v1/session")]
    public class SessionController : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Ong>>Session([FromServices] DataContext context, int id)
        {
            
            var ong = await context.Ong.FindAsync(id);
            if(ong != null)
            {
                return ong;
            }
            return NotFound();
        }
    }
}