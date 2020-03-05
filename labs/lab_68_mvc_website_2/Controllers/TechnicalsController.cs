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
    public class TechnicalsController : Controller
    {
        private readonly F1TeamDbContext _context;

        public TechnicalsController(F1TeamDbContext context)
        {
            _context = context;
        }

        // GET: Technicals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicals.ToListAsync());
        }

        // GET: Technicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technical = await _context.Technicals
                .FirstOrDefaultAsync(m => m.TechnicalID == id);
            if (technical == null)
            {
                return NotFound();
            }

            return View(technical);
        }

        // GET: Technicals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Technicals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicalID,AeroRating,EngineSupplier,ChassisRating,TeamBudget")] Technical technical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technical);
        }

        // GET: Technicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technical = await _context.Technicals.FindAsync(id);
            if (technical == null)
            {
                return NotFound();
            }
            return View(technical);
        }

        // POST: Technicals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechnicalID,AeroRating,EngineSupplier,ChassisRating,TeamBudget")] Technical technical)
        {
            if (id != technical.TechnicalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalExists(technical.TechnicalID))
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
            return View(technical);
        }

        // GET: Technicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technical = await _context.Technicals
                .FirstOrDefaultAsync(m => m.TechnicalID == id);
            if (technical == null)
            {
                return NotFound();
            }

            return View(technical);
        }

        // POST: Technicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technical = await _context.Technicals.FindAsync(id);
            _context.Technicals.Remove(technical);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalExists(int id)
        {
            return _context.Technicals.Any(e => e.TechnicalID == id);
        }
    }
}
