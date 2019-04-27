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
    public class LocationRoomsController : Controller
    {
        private readonly LocationContext _context;

        public LocationRoomsController(LocationContext context)
        {
            _context = context;
        }

        // GET: LocationRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationRoom.ToListAsync());
        }

        // GET: LocationRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRoom = await _context.LocationRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationRoom == null)
            {
                return NotFound();
            }

            return View(locationRoom);
        }

        // GET: LocationRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomName,RoomShortCode")] LocationRoom locationRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationRoom);
        }

        // GET: LocationRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRoom = await _context.LocationRoom.FindAsync(id);
            if (locationRoom == null)
            {
                return NotFound();
            }
            return View(locationRoom);
        }

        // POST: LocationRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoomName,RoomShortCode")] LocationRoom locationRoom)
        {
            if (id != locationRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationRoomExists(locationRoom.Id))
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
            return View(locationRoom);
        }

        // GET: LocationRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationRoom = await _context.LocationRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationRoom == null)
            {
                return NotFound();
            }

            return View(locationRoom);
        }

        // POST: LocationRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationRoom = await _context.LocationRoom.FindAsync(id);
            _context.LocationRoom.Remove(locationRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationRoomExists(int id)
        {
            return _context.LocationRoom.Any(e => e.Id == id);
        }
    }
}
