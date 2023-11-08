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
    public class DevicesController : Controller
    {
        private readonly AppDbContext _context;

        public DevicesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.devices.Include(d => d.UserDevice);
        //    return View(await appDbContext.ToListAsync());
        //}




        //public async Task<IActionResult> Index(int? UserIdDevice)
        //{


        //    if (UserIdDevice != null)
        //    {
        //        var AppDbContext = _context.devices
        //            .Include(v => v.UserDevice)
        //            .Where(o => o.UserIdDevice == UserIdDevice);
        //        return View(await AppDbContext.ToListAsync());
        //    }
        //    else
        //    {
        //        var appDbContext = _context.devices.Include(c => c.UserDevice);
        //        return View(await appDbContext.ToListAsync());
        //    }
        //}

        public async Task<IActionResult> SearchDevice(string Search, string Criteria)
        {
            if (Search != null)
            {
                if (Criteria == "Brand")
                {
                    var FindData = _context.devices.Include(d => d.UserDevice).Where(d => d.Brand.Contains(Search)).ToList();
                    if (FindData.Count == 0)
                    {
                        ViewBag.Msg = "Geen apparaten gevonden";
                        return View();
                    }
                    else
                    {
                        return View(FindData);
                    }
                }

                if (Criteria == "Category")
                {
                    var FindData = _context.devices.Include(d => d.UserDevice).Where(d => d.Category.Contains(Search)).ToList();
                    if (FindData.Count == 0)
                    {
                        ViewBag.Msg = "Geen apparaten gevonden";
                        return View();
                    }
                    else
                    {
                        return View(FindData);
                    }
                }

                if (Criteria == "Model")
                {
                    var FindData = _context.devices.Include(d => d.UserDevice).Where(d => d.Model.Contains(Search)).ToList();
                    if (FindData.Count == 0)
                    {
                        ViewBag.Msg = "Geen apparaten gevonden";
                        return View();
                    }
                    else
                    {
                        return View(FindData);
                    }
                }


            }
            var obj = _context.devices.Include(d => d.UserDevice).ToList();
            return View(obj);
        }


        public async Task<IActionResult> Index()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            if (userId != null)
            {
                var AppDbContext = _context.devices
                    .Include(d => d.UserDevice)
                    .Where(d => d.UserIdDevice == userId);
                return View(await AppDbContext.ToListAsync());
            }
            else
            {
                var appDbContext = _context.devices.Include(c => c.UserDevice);
                return View(await appDbContext.ToListAsync());
            }
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices
                .Include(d => d.UserDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            //ViewData["UserIdDevice"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,energyLabel,KwH,manufactureDate,warrentyEndDate,Category,lifeSpan")] Device device)
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            device.UserIdDevice = userId;

            // User ophalen en zijn punten,geuploade devices updaten

            User user = _context.Users.FirstOrDefault(u => u.Id == userId);
            user.UploadedDevices += 1;
            //user.Points += 5;
            user.GetPoints(_context,5);
            // Controleren of level om hoog moet gaan en bijwerken

            int uploadedDevices = user.UploadedDevices + 1;
            // Hier kunnen we de voorwarden van de level veranderen bijvoorbeeld elke 2 geuploade apparaten of meer 
            //if (uploadedDevices % 2 == 0)
            //{
            //    user.Level++;
            //}
            user.LevelUp(_context);
            _context.Add(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        } 

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["UserIdDevice"] = new SelectList(_context.Users, "Id", "Name", device.UserIdDevice);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,energyLabel,KwH,manufactureDate,warrentyEndDate,Category,lifeSpan,UserIdDevice")] Device device)
        {
            if (id != device.Id)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Id))
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

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.devices == null)
            {
                return NotFound();
            }

            var device = await _context.devices
                .Include(d => d.UserDevice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.devices == null)
            {
                return Problem("Entity set 'AppDbContext.devices'  is null.");
            }
            var device = await _context.devices.FindAsync(id);
            if (device != null)
            {
                _context.devices.Remove(device);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
          return (_context.devices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
