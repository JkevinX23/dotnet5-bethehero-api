using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bethehero_api.Data;
using bethehero_api.Models;
using System;

namespace bethehero_api.Controllers
{
    [ApiController]
    [Route("v1/ongs")]
    public class OngController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Ong>>> Get([FromServices] DataContext context)
        {
            var ongs = await context.Ong.ToListAsync();
            return ongs;
        }


        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Ong>> Post([FromServices] DataContext context, [FromBody] Ong model)
        {
            if (ModelState.IsValid)
            {
                Random randNum = new Random();
                model.Id = randNum.Next(1000,9000);
                context.Ong.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            return BadRequest(ModelState);
        }
    }
}