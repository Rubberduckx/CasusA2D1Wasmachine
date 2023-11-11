using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCasusWasmachine.Data;
using WebApplicationCasusWasmachine.Models;

namespace WebApplicationCasusWasmachineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsingReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsingReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UsingReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsingReport>>> GetUsingReports()
        {
          if (_context.UsingReports == null)
          {
              return NotFound();
          }
            return await _context.UsingReports.ToListAsync();
        }

        // GET: api/UsingReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsingReport>> GetUsingReport(int id)
        {
          if (_context.UsingReports == null)
          {
              return NotFound();
          }
            var usingReport = await _context.UsingReports.FindAsync(id);

            if (usingReport == null)
            {
                return NotFound();
            }

            return usingReport;
        }

        // PUT: api/UsingReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsingReport(int id, UsingReport usingReport)
        {
            if (id != usingReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(usingReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsingReportExists(id))
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

        // POST: api/UsingReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsingReport>> PostUsingReport(UsingReport usingReport)
        {
          if (_context.UsingReports == null)
          {
              return Problem("Entity set 'AppDbContext.UsingReports'  is null.");
          }
            _context.UsingReports.Add(usingReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsingReport", new { id = usingReport.Id }, usingReport);
        }

        // DELETE: api/UsingReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsingReport(int id)
        {
            if (_context.UsingReports == null)
            {
                return NotFound();
            }
            var usingReport = await _context.UsingReports.FindAsync(id);
            if (usingReport == null)
            {
                return NotFound();
            }

            _context.UsingReports.Remove(usingReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsingReportExists(int id)
        {
            return (_context.UsingReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
