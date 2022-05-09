#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusDetails_TableDisplay.Models;

namespace BusDetails_TableDisplay.Controllers
{
    public class BusDataController : Controller
    {
        BusDBContext contextData = new BusDBContext();
        private readonly BusDBContext _context;

        public IActionResult List()
        {
            var data = contextData.BusInfos.FromSqlInterpolated($"execute getBusdata");
            return View(data);
        }
        public BusDataController(BusDBContext context)
        {
            _context = context;
        }

        // GET: BusData
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusInfos.ToListAsync());
        }

        // GET: BusData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfos
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (busInfo == null)
            {
                return NotFound();
            }

            return View(busInfo);
        }

        // GET: BusData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusId,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busInfo);
        }

        // GET: BusData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfos.FindAsync(id);
            if (busInfo == null)
            {
                return NotFound();
            }
            return View(busInfo);
        }

        // POST: BusData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusId,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        {
            if (id != busInfo.BusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusInfoExists(busInfo.BusId))
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
            return View(busInfo);
        }

        // GET: BusData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busInfo = await _context.BusInfos
                .FirstOrDefaultAsync(m => m.BusId == id);
            if (busInfo == null)
            {
                return NotFound();
            }

            return View(busInfo);
        }

        // POST: BusData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busInfo = await _context.BusInfos.FindAsync(id);
            _context.BusInfos.Remove(busInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusInfoExists(int id)
        {
            return _context.BusInfos.Any(e => e.BusId == id);
        }
    }
}
