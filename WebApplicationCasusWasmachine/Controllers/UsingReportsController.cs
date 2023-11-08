using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCasusWasmachine.Data;
using WebApplicationCasusWasmachine.Models;

namespace WebApplicationCasusWasmachine.Controllers
{
    public class UsingReportsController : Controller
    {
        private readonly AppDbContext _context;

        public UsingReportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UsingReports
        public async Task<IActionResult> Index(int? DeviceId)
        {
            if (DeviceId != null)
            {
                var AppDbContext = _context.UsingReports
                    .Include(v => v.Device)
                    .Where(o => o.DeviceId == DeviceId);
                return View(await AppDbContext.ToListAsync());
            }
            else
            {
                var appDbContext = _context.UsingReports.Include(c => c.Device);
                return View(await appDbContext.ToListAsync());
            }
        }

        // GET: UsingReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UsingReports == null)
            {
                return NotFound();
            }

            var usingReport = await _context.UsingReports
                .Include(u => u.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usingReport == null)
            {
                return NotFound();
            }

            return View(usingReport);
        }

        // GET: UsingReports/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.devices, "Id", "Brand");
            return View();
        }

        // POST: UsingReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DeviceName,Duration,Setting,DeviceId")] UsingReport usingReport)
        {

            _context.Add(usingReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            //if (ModelState.IsValid)
            //{
            //    _context.Add(usingReport);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["DeviceId"] = new SelectList(_context.devices, "Id", "Brand", usingReport.DeviceId);
            //return View(usingReport);
        }

        // GET: UsingReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UsingReports == null)
            {
                return NotFound();
            }

            var usingReport = await _context.UsingReports.FindAsync(id);
            if (usingReport == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.devices, "Id", "Brand", usingReport.DeviceId);
            return View(usingReport);
        }

        // POST: UsingReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DeviceName,Duration,Setting,DeviceId")] UsingReport usingReport)
        {
            if (id != usingReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usingReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsingReportExists(usingReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.devices, "Id", "Brand", usingReport.DeviceId);
            return View(usingReport);
        }

        // GET: UsingReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UsingReports == null)
            {
                return NotFound();
            }

            var usingReport = await _context.UsingReports
                .Include(u => u.Device)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usingReport == null)
            {
                return NotFound();
            }

            return View(usingReport);
        }

        // POST: UsingReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UsingReports == null)
            {
                return Problem("Entity set 'AppDbContext.UsingReports'  is null.");
            }
            var usingReport = await _context.UsingReports.FindAsync(id);
            if (usingReport != null)
            {
                _context.UsingReports.Remove(usingReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsingReportExists(int id)
        {
          return (_context.UsingReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
