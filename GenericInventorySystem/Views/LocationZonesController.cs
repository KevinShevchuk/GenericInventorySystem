using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenericInventorySystem.Models;
using GenericInventorySystem.Models.Location;

namespace GenericInventorySystem.Views
{
    public class LocationZonesController : Controller
    {
        private readonly LocationContext _context;

        public LocationZonesController(LocationContext context)
        {
            _context = context;
        }

        // GET: LocationZones
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationZone.ToListAsync());
        }

        // GET: LocationZones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationZone = await _context.LocationZone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationZone == null)
            {
                return NotFound();
            }

            return View(locationZone);
        }

        // GET: LocationZones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationZones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZoneName,ZoneShortCode")] LocationZone locationZone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationZone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationZone);
        }

        // GET: LocationZones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationZone = await _context.LocationZone.FindAsync(id);
            if (locationZone == null)
            {
                return NotFound();
            }
            return View(locationZone);
        }

        // POST: LocationZones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZoneName,ZoneShortCode")] LocationZone locationZone)
        {
            if (id != locationZone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationZone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationZoneExists(locationZone.Id))
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
            return View(locationZone);
        }

        // GET: LocationZones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationZone = await _context.LocationZone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationZone == null)
            {
                return NotFound();
            }

            return View(locationZone);
        }

        // POST: LocationZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationZone = await _context.LocationZone.FindAsync(id);
            _context.LocationZone.Remove(locationZone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationZoneExists(int id)
        {
            return _context.LocationZone.Any(e => e.Id == id);
        }
    }
}
