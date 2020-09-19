using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleMvc.Data;
using SampleMvc.Data.Models;

namespace SampleMvc.Controllers
{
    [Route("api/patrimonios")]
    [ApiController]
    public class PatrimoniosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatrimoniosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Patrimonios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patrimonio>>> GetPatrimonio([FromQuery] string localNome)
        {
            return await _context.Patrimonio
                .Include(p => p.Local)
                .Where(p => p.Local.Nome == localNome)
                .ToListAsync();
        }

        // GET: api/Patrimonios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patrimonio>> GetPatrimonio(int id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return patrimonio;
        }

        // PUT: api/Patrimonios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatrimonio(int id, Patrimonio patrimonio)
        {
            if (id != patrimonio.Id)
            {
                return BadRequest();
            }

            _context.Entry(patrimonio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatrimonioExists(id))
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

        // POST: api/Patrimonios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patrimonio>> PostPatrimonio(Patrimonio patrimonio)
        {
            _context.Patrimonio.Add(patrimonio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatrimonio", new { id = patrimonio.Id }, patrimonio);
        }

        // DELETE: api/Patrimonios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patrimonio>> DeletePatrimonio(int id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            _context.Patrimonio.Remove(patrimonio);
            await _context.SaveChangesAsync();

            return patrimonio;
        }

        private bool PatrimonioExists(int id)
        {
            return _context.Patrimonio.Any(e => e.Id == id);
        }
    }
}