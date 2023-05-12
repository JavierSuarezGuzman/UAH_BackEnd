using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_tareas.Models;

namespace API_tareas.Controllers
{
    //https://localhost:7126/api/TareaItems
    //[Route("api/[controller]")]
    [Route("api/tareas")]
    [ApiController]
    public class TareaItemsController : ControllerBase
    {
        private readonly TareaContext _context;

        public TareaItemsController(TareaContext context)
        {
            _context = context;
        }

        // GET: api/TareaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TareaItem>>> GetTareaItems()
        {
          if (_context.TareaItems == null)
          {
              return NotFound();
          }
            return await _context.TareaItems.ToListAsync();
        }

        // GET: api/TareaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TareaItem>> GetTareaItem(long id)
        {
          if (_context.TareaItems == null)
          {
              return NotFound();
          }
            var tareaItem = await _context.TareaItems.FindAsync(id);

            if (tareaItem == null)
            {
                return NotFound();
            }

            return tareaItem;
        }

        // PUT: api/TareaItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTareaItem(long id, TareaItem tareaItem)
        {
            if (id != tareaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tareaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaItemExists(id))
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

        // POST: api/TareaItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TareaItem>> PostTareaItem(TareaItem tareaItem)
        {
          if (_context.TareaItems == null)
          {
              return Problem("Entity set 'TareaContext.TareaItems'  is null.");
          }
            _context.TareaItems.Add(tareaItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTareaItem", new { id = tareaItem.Id }, tareaItem);
            // Update the return statement in the PostTodoItem to use the nameof operator:
            return CreatedAtAction(nameof(GetTareaItem), new { id = tareaItem.Id }, tareaItem);
        }

        // DELETE: api/TareaItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTareaItem(long id)
        {
            if (_context.TareaItems == null)
            {
                return NotFound();
            }
            var tareaItem = await _context.TareaItems.FindAsync(id);
            if (tareaItem == null)
            {
                return NotFound();
            }

            _context.TareaItems.Remove(tareaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaItemExists(long id)
        {
            return (_context.TareaItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
