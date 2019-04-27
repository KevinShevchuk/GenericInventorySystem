using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenericInventorySystem.Models;

namespace GenericInventorySystem.Views
{
    public class LocationBuildingsController : Controller
    {
        private readonly LocationContext _context;

        public LocationBuildingsController(LocationContext context)
        {
            _context = context;
        }

        // GET: LocationBuildings
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationBuilding.ToListAsync());
        }

        // GET: LocationBuildings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationBuilding = await _context.LocationBuilding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationBuilding == null)
            {
                return NotFound();
            }

            return View(locationBuilding);
        }

        // GET: LocationBuildings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationBuildings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuildingName,BuildingShortCode")] LocationBuilding locationBuilding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationBuilding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationBuilding);
        }

        // GET: LocationBuildings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationBuilding = await _context.LocationBuilding.FindAsync(id);
            if (locationBuilding == null)
            {
                return NotFound();
            }
            return View(locationBuilding);
        }

        // POST: LocationBuildings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuildingName,BuildingShortCode")] LocationBuilding locationBuilding)
        {
            if (id != locationBuilding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationBuilding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationBuildingExists(locationBuilding.Id))
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
            return View(locationBuilding);
        }

        // GET: LocationBuildings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationBuilding = await _context.LocationBuilding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationBuilding == null)
            {
                return NotFound();
            }

            return View(locationBuilding);
        }

        // POST: LocationBuildings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationBuilding = await _context.LocationBuilding.FindAsync(id);
            _context.LocationBuilding.Remove(locationBuilding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationBuildingExists(int id)
        {
            return _context.LocationBuilding.Any(e => e.Id == id);
        }
    }
}
