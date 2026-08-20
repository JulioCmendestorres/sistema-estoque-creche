using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESTOQUE_CRECHE.Models;

namespace ESTOQUE_CRECHE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceirosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParceirosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parceiro>>> GetParceiros()
        {
            return await _context.Parceiros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parceiro>> GetParceiro(int id)
        {
            var parceiro = await _context.Parceiros.FindAsync(id);

            if (parceiro == null)
            {
                return NotFound();
            }

            return parceiro;
        }

        [HttpPost]
        public async Task<ActionResult<Parceiro>> PostParceiro(Parceiro parceiro)
        {
            _context.Parceiros.Add(parceiro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParceiro), new { id = parceiro.Id }, parceiro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutParceiro(int id, Parceiro parceiro)
        {
            if (id != parceiro.Id)
            {
                return BadRequest("O ID da URL é diferente do ID do corpo da requisição.");
            }

            _context.Entry(parceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParceiroExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParceiro(int id)
        {
            var parceiro = await _context.Parceiros.FindAsync(id);
            if (parceiro == null)
            {
                return NotFound();
            }

            _context.Parceiros.Remove(parceiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParceiroExists(int id)
        {
            return _context.Parceiros.Any(e => e.Id == id);
        }
    }
}