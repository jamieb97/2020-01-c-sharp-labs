using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_68_mvc_website_2.Models;

namespace lab_68_mvc_website_2.Controllers
{
    public class PrinciplesController : Controller
    {
        private readonly F1TeamDbContext _context;

        public PrinciplesController(F1TeamDbContext context)
        {
            _context = context;
        }

        // GET: Principles
        public async Task<IActionResult> Index()
        {
            var f1TeamDbContext = _context.Principles.Include(p => p.Team).Include(p => p.Technical);
            return View(await f1TeamDbContext.ToListAsync());
        }

        // GET: Principles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principle = await _context.Principles
                .Include(p => p.Team)
                .Include(p => p.Technical)
                .FirstOrDefaultAsync(m => m.PrincipleID == id);
            if (principle == null)
            {
                return NotFound();
            }

            return View(principle);
        }

        // GET: Principles/Create
        public IActionResult Create()
        {
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID");
            ViewData["TechnicalID"] = new SelectList(_context.Technicals, "TechnicalID", "TechnicalID");
            return View();
        }

        // POST: Principles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrincipleID,PrincipleName,TeamID,StrategyPlan,TechnicalID")] Principle principle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(principle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", principle.TeamID);
            ViewData["TechnicalID"] = new SelectList(_context.Technicals, "TechnicalID", "TechnicalID", principle.TechnicalID);
            return View(principle);
        }

        // GET: Principles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principle = await _context.Principles.FindAsync(id);
            if (principle == null)
            {
                return NotFound();
            }
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", principle.TeamID);
            ViewData["TechnicalID"] = new SelectList(_context.Technicals, "TechnicalID", "TechnicalID", principle.TechnicalID);
            return View(principle);
        }

        // POST: Principles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrincipleID,PrincipleName,TeamID,StrategyPlan,TechnicalID")] Principle principle)
        {
            if (id != principle.PrincipleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(principle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipleExists(principle.PrincipleID))
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
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", principle.TeamID);
            ViewData["TechnicalID"] = new SelectList(_context.Technicals, "TechnicalID", "TechnicalID", principle.TechnicalID);
            return View(principle);
        }

        // GET: Principles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principle = await _context.Principles
                .Include(p => p.Team)
                .Include(p => p.Technical)
                .FirstOrDefaultAsync(m => m.PrincipleID == id);
            if (principle == null)
            {
                return NotFound();
            }

            return View(principle);
        }

        // POST: Principles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var principle = await _context.Principles.FindAsync(id);
            _context.Principles.Remove(principle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrincipleExists(int id)
        {
            return _context.Principles.Any(e => e.PrincipleID == id);
        }
    }
}
