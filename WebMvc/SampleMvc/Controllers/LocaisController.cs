using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleMvc.Data;
using SampleMvc.Data.Models;

namespace SampleMvc.Controllers
{
    [Route("api/locais")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Locais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocal()
        {
            return await _context.Local.ToListAsync();
        }

        // GET: api/Locais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _context.Local.FindAsync(id);

            if (local == null)
            {
                return NotFound();
            }

            return local;
        }

        // PUT: api/Locais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(int id, Local local)
        {
            if (id != local.Id)
            {
                return BadRequest();
            }

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalExists(id))
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

        // POST: api/Locais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            _context.Local.Add(local);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocal", new { id = local.Id }, local);
        }

        // DELETE: api/Locais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Local>> DeleteLocal(int id)
        {
            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Local.Remove(local);
            await _context.SaveChangesAsync();

            return local;
        }

        private bool LocalExists(int id)
        {
            return _context.Local.Any(e => e.Id == id);
        }
    }
}