/* Javier Suárez Guzmán 
 * Mayo 2023 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_tareas.Models;
using Microsoft.AspNetCore.Cors;

namespace API_tareas.Controllers
{
    //[EnableCors("MyPolicy")]
    [Route("api/alumnos")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoDbContext _context;

        public AlumnosController(AlumnoDbContext context)
        {
            _context = context;
        }

        // GET: api/alumnos
        //[DisableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
          if (_context.Alumnos == null)
          {
              return NotFound();
          }
            return await _context.Alumnos.ToListAsync();
        }

        // GET: api/alumnos/nombre
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(string id)
        {
          if (_context.Alumnos == null)
          {
              return NotFound();
          }
            var alumno = await _context.Alumnos.FindAsync(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(string id, Alumno alumno)
        {
            if (id != alumno.Nombre)
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
          if (_context.Alumnos == null)
          {
              return Problem("Entity set 'AlumnoDbContext.Alumnos'  is null.");
          }
            _context.Alumnos.Add(alumno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlumnoExists(alumno.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlumno", new { id = alumno.Nombre }, alumno);
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(string id)
        {
            if (_context.Alumnos == null)
            {
                return NotFound();
            }
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnoExists(string id)
        {
            return (_context.Alumnos?.Any(e => e.Nombre == id)).GetValueOrDefault();
        }
    }
}
