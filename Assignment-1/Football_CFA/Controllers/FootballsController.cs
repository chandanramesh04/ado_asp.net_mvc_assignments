#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Football_CFA.Models;

namespace Football_CFA.Controllers
{
    public class FootballsController : Controller
    {
        private readonly FootballContext _context;

        public FootballsController(FootballContext context)
        {
            _context = context;
        }

        // GET: Footballs
        public async Task<IActionResult> Index()
        {
            return View(await _context.FootballData.ToListAsync());
        }

        // GET: Footballs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.FootballData
                .FirstOrDefaultAsync(m => m.MatchID == id);
            if (football == null)
            {
                return NotFound();
            }

            return View(football);
        }

        // GET: Footballs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Footballs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] Football football)
        {
            if (ModelState.IsValid)
            {
                _context.Add(football);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(football);
        }

        // GET: Footballs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.FootballData.FindAsync(id);
            if (football == null)
            {
                return NotFound();
            }
            return View(football);
        }

        // POST: Footballs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] Football football)
        {
            if (id != football.MatchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(football);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballExists(football.MatchID))
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
            return View(football);
        }

        // GET: Footballs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var football = await _context.FootballData
                .FirstOrDefaultAsync(m => m.MatchID == id);
            if (football == null)
            {
                return NotFound();
            }

            return View(football);
        }

        // POST: Footballs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var football = await _context.FootballData.FindAsync(id);
            _context.FootballData.Remove(football);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballExists(int id)
        {
            return _context.FootballData.Any(e => e.MatchID == id);
        }
    }
}
