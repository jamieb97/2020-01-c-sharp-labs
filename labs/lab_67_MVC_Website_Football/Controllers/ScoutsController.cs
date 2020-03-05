using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_65_Football_API.Models;

namespace lab_67_MVC_Website_Football.Controllers
{
    public class ScoutsController : Controller
    {
        private readonly FootballDbContext _context;

        public ScoutsController(FootballDbContext context)
        {
            _context = context;
        }

        // GET: Scouts
        public async Task<IActionResult> Index()
        {
            var footballDbContext = _context.Scouts.Include(s => s.Player);
            return View(await footballDbContext.ToListAsync());
        }

        // GET: Scouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scout = await _context.Scouts
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.ScoutID == id);
            if (scout == null)
            {
                return NotFound();
            }

            return View(scout);
        }

        // GET: Scouts/Create
        public IActionResult Create()
        {
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID");
            return View();
        }

        // POST: Scouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScoutID,ScoutName,PlayerID,CountryBased,StaffAmount")] Scout scout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID", scout.PlayerID);
            return View(scout);
        }

        // GET: Scouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scout = await _context.Scouts.FindAsync(id);
            if (scout == null)
            {
                return NotFound();
            }
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID", scout.PlayerID);
            return View(scout);
        }

        // POST: Scouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScoutID,ScoutName,PlayerID,CountryBased,StaffAmount")] Scout scout)
        {
            if (id != scout.ScoutID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScoutExists(scout.ScoutID))
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
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID", scout.PlayerID);
            return View(scout);
        }

        // GET: Scouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scout = await _context.Scouts
                .Include(s => s.Player)
                .FirstOrDefaultAsync(m => m.ScoutID == id);
            if (scout == null)
            {
                return NotFound();
            }

            return View(scout);
        }

        // POST: Scouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scout = await _context.Scouts.FindAsync(id);
            _context.Scouts.Remove(scout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScoutExists(int id)
        {
            return _context.Scouts.Any(e => e.ScoutID == id);
        }
    }
}
