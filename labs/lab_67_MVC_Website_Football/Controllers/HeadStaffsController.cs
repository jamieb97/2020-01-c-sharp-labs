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
    public class HeadStaffsController : Controller
    {
        private readonly FootballDbContext _context;

        public HeadStaffsController(FootballDbContext context)
        {
            _context = context;
        }

        // GET: HeadStaffs
        public async Task<IActionResult> Index()
        {
            var footballDbContext = _context.HeadStaffs.Include(h => h.Owner).Include(h => h.Scout);
            return View(await footballDbContext.ToListAsync());
        }

        // GET: HeadStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headStaff = await _context.HeadStaffs
                .Include(h => h.Owner)
                .Include(h => h.Scout)
                .FirstOrDefaultAsync(m => m.HeadStaffID == id);
            if (headStaff == null)
            {
                return NotFound();
            }

            return View(headStaff);
        }

        // GET: HeadStaffs/Create
        public IActionResult Create()
        {
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID");
            ViewData["ScoutID"] = new SelectList(_context.Scouts, "ScoutID", "ScoutID");
            return View();
        }

        // POST: HeadStaffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeadStaffID,OwnerID,StaffName,StaffRole,ScoutID")] HeadStaff headStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", headStaff.OwnerID);
            ViewData["ScoutID"] = new SelectList(_context.Scouts, "ScoutID", "ScoutID", headStaff.ScoutID);
            return View(headStaff);
        }

        // GET: HeadStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headStaff = await _context.HeadStaffs.FindAsync(id);
            if (headStaff == null)
            {
                return NotFound();
            }
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", headStaff.OwnerID);
            ViewData["ScoutID"] = new SelectList(_context.Scouts, "ScoutID", "ScoutID", headStaff.ScoutID);
            return View(headStaff);
        }

        // POST: HeadStaffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeadStaffID,OwnerID,StaffName,StaffRole,ScoutID")] HeadStaff headStaff)
        {
            if (id != headStaff.HeadStaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadStaffExists(headStaff.HeadStaffID))
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
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", headStaff.OwnerID);
            ViewData["ScoutID"] = new SelectList(_context.Scouts, "ScoutID", "ScoutID", headStaff.ScoutID);
            return View(headStaff);
        }

        // GET: HeadStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headStaff = await _context.HeadStaffs
                .Include(h => h.Owner)
                .Include(h => h.Scout)
                .FirstOrDefaultAsync(m => m.HeadStaffID == id);
            if (headStaff == null)
            {
                return NotFound();
            }

            return View(headStaff);
        }

        // POST: HeadStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headStaff = await _context.HeadStaffs.FindAsync(id);
            _context.HeadStaffs.Remove(headStaff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadStaffExists(int id)
        {
            return _context.HeadStaffs.Any(e => e.HeadStaffID == id);
        }
    }
}
