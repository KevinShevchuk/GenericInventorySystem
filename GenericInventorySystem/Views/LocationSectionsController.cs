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
    public class LocationSectionsController : Controller
    {
        private readonly LocationContext _context;

        public LocationSectionsController(LocationContext context)
        {
            _context = context;
        }

        // GET: LocationSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationSection.ToListAsync());
        }

        // GET: LocationSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSection = await _context.LocationSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationSection == null)
            {
                return NotFound();
            }

            return View(locationSection);
        }

        // GET: LocationSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationSections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SectionName,SectionShortCode")] LocationSection locationSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationSection);
        }

        // GET: LocationSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSection = await _context.LocationSection.FindAsync(id);
            if (locationSection == null)
            {
                return NotFound();
            }
            return View(locationSection);
        }

        // POST: LocationSections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SectionName,SectionShortCode")] LocationSection locationSection)
        {
            if (id != locationSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationSectionExists(locationSection.Id))
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
            return View(locationSection);
        }

        // GET: LocationSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationSection = await _context.LocationSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationSection == null)
            {
                return NotFound();
            }

            return View(locationSection);
        }

        // POST: LocationSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationSection = await _context.LocationSection.FindAsync(id);
            _context.LocationSection.Remove(locationSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationSectionExists(int id)
        {
            return _context.LocationSection.Any(e => e.Id == id);
        }
    }
}
