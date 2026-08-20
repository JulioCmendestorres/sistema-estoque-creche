using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESTOQUE_CRECHE.Models;

namespace ESTOQUE_CRECHE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasItensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasItensController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaItem>>> GetCategoriasItens()
        {
            return await _context.CategoriasItens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaItem>> GetCategoriaItem(int id)
        {
            var categoriaItem = await _context.CategoriasItens.FindAsync(id);

            if (categoriaItem == null)
            {
                return NotFound();
            }

            return categoriaItem;
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaItem>> PostCategoriaItem(CategoriaItem categoriaItem)
        {
            _context.CategoriasItens.Add(categoriaItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoriaItem), new { id = categoriaItem.Id }, categoriaItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaItem(int id, CategoriaItem categoriaItem)
        {
            if (id != categoriaItem.Id)
            {
                return BadRequest("O ID da URL é diferente do ID do corpo da requisição.");
            }

            _context.Entry(categoriaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaItemExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaItem(int id)
        {
            var categoriaItem = await _context.CategoriasItens.FindAsync(id);
            if (categoriaItem == null)
            {
                return NotFound();
            }

            _context.CategoriasItens.Remove(categoriaItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaItemExists(int id)
        {
            return _context.CategoriasItens.Any(e => e.Id == id);
        }
    }
}