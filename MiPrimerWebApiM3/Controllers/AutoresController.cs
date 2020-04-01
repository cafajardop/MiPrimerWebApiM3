using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Contexts;
using MiPrimerWebApiM3.Entities;
using MiPrimerWebApiM3.Helpers;
using MiPrimerWebApiM3.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerWebApiM3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IClaseB claseB;

        public AutoresController(ApplicationDbContext context, IClaseB claseB)
        {
            this.context = context;
            this.claseB = claseB;
        }
        //GET api/autores => //localhost:44326/api/autores/listado ó //localhost:44326/listado
        [HttpGet("/listado")]
        [HttpGet("listado")]
        [HttpGet]
        [ServiceFilter(typeof(MiFiltro))]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            throw new NotImplementedException();
            claseB.HacerAlgo();
            return context.Autores.Include(x => x.Libros).ToList();
        }
        [HttpGet("Primer")]
        public ActionResult<Autor> GetPrimerAutor()
        {
            return context.Autores.FirstOrDefault();
        }
        //GET api/autores/5  ó  GET api/autores/5/Carlos
        [HttpGet("{id}/{param2?}", Name ="ObtenerAutor")]
        public async Task<ActionResult<Autor>> Get(int id, [Required] string nombre)
        {
            var autor = await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);

            if(autor == null)
            {
                return NotFound();
            }
            return autor;
        }
        // POST api/autores
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            TryValidateModel(autor);
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        }
        [HttpPut("{id}")]
        public ActionResult<Autor> Put(int id, [FromBody] Autor value)
        {
            if(id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }
            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }

    }
}
