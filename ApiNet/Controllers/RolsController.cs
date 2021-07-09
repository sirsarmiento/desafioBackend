using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiNet.Contexts;
using ApiNet.Entities;

namespace ApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsController : ControllerBase
    {
        private readonly AppDbContext context;

        public RolsController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<RolController>
        [HttpGet]
        public IEnumerable<ApplicationRol> Get()
        {
            return context.ApplicationRol.ToList();

        }


        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public ApplicationRol Get(Guid id)
        {
            var rol = context.ApplicationRol.FirstOrDefault(p => p.RolId == id);
            return rol;
        }

        // POST api/<RolController>
        [HttpPost]
        public ActionResult Post([FromBody] ApplicationRol aplicationRol)
        {
            try
            {
                context.ApplicationRol.Add(aplicationRol);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] ApplicationRol aplicationRol)
        {
            if (aplicationRol.RolId == id)
            {
                context.Entry(aplicationRol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var rol = context.ApplicationRol.FirstOrDefault(p => p.RolId == id);
            if (rol != null)
            {
                context.ApplicationRol.Remove(rol);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
