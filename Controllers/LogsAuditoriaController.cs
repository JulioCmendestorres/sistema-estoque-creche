using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESTOQUE_CRECHE.Models;

namespace ESTOQUE_CRECHE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsAuditoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogsAuditoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogAuditoria>>> GetLogsAuditoria()
        {
            return await _context.LogsAuditoria.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LogAuditoria>> GetLogAuditoria(int id)
        {
            var logAuditoria = await _context.LogsAuditoria.FindAsync(id);

            if (logAuditoria == null)
            {
                return NotFound();
            }

            return logAuditoria;
        }

        [HttpPost]
        public async Task<ActionResult<LogAuditoria>> PostLogAuditoria(LogAuditoria logAuditoria)
        {
            _context.LogsAuditoria.Add(logAuditoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLogAuditoria), new { id = logAuditoria.Id }, logAuditoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogAuditoria(int id, LogAuditoria logAuditoria)
        {
            if (id != logAuditoria.Id)
            {
                return BadRequest("O ID da URL é diferente do ID do corpo da requisição.");
            }

            _context.Entry(logAuditoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogAuditoriaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogAuditoria(int id)
        {
            var logAuditoria = await _context.LogsAuditoria.FindAsync(id);
            if (logAuditoria == null)
            {
                return NotFound();
            }

            _context.LogsAuditoria.Remove(logAuditoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogAuditoriaExists(int id)
        {
            return _context.LogsAuditoria.Any(e => e.Id == id);
        }
    }
}