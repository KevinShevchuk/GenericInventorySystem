using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GenericInventorySystem.Models;

namespace GenericInventorySystem.Views
{
    public class LocationAddressesController : Controller
    {
        private readonly LocationContext _context;

        public LocationAddressesController(LocationContext context)
        {
            _context = context;
        }

        // GET: LocationAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocationAddress.ToListAsync());
        }

        // GET: LocationAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationAddress = await _context.LocationAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationAddress == null)
            {
                return NotFound();
            }

            return View(locationAddress);
        }

        // GET: LocationAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocationAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddressLine1,AddressLine2,City,State,PostalCode,AddressShortCode")] LocationAddress locationAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationAddress);
        }

        // GET: LocationAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationAddress = await _context.LocationAddress.FindAsync(id);
            if (locationAddress == null)
            {
                return NotFound();
            }
            return View(locationAddress);
        }

        // POST: LocationAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddressLine1,AddressLine2,City,State,PostalCode,AddressShortCode")] LocationAddress locationAddress)
        {
            if (id != locationAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationAddressExists(locationAddress.Id))
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
            return View(locationAddress);
        }

        // GET: LocationAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locationAddress = await _context.LocationAddress
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locationAddress == null)
            {
                return NotFound();
            }

            return View(locationAddress);
        }

        // POST: LocationAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationAddress = await _context.LocationAddress.FindAsync(id);
            _context.LocationAddress.Remove(locationAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationAddressExists(int id)
        {
            return _context.LocationAddress.Any(e => e.Id == id);
        }
    }
}
