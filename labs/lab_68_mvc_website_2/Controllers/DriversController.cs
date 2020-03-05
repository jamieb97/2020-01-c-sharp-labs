#define API
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_68_mvc_website_2.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace lab_68_mvc_website_2.Controllers
{
    public class DriversController : Controller
    {
        private readonly F1TeamDbContext _context;
        static Uri url = new Uri("https://localhost:44360/api/players");
        public DriversController(F1TeamDbContext context)
        {
            _context = context;
        }
#if API
        //GET Player data
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetDriverDataAsync();
                var drivers = JsonConvert.DeserializeObject<List<Driver>>(jsonString);
                return View(drivers);
            }
        }
        static async Task<string> GetDriverDataAsync()
        {
            string jsonString = null;
            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            return jsonString;
        }

        //Post Player data
        static async Task PostPlayerAsync()
        {

        }
#else
        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var f1TeamDbContext = _context.Drivers.Include(d => d.Car).Include(d => d.Team);
            return View(await f1TeamDbContext.ToListAsync());
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(d => d.Car)
                .Include(d => d.Team)
                .FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }


        // GET: Drivers/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarID");
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID");
            return View();
        }

        // POST: Drivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverID,DriverRole,Name,ContractLength,TeamID,StrategyPlan,CarID")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarID", driver.CarID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", driver.TeamID);
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarID", driver.CarID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", driver.TeamID);
            return View(driver);
        }

        // POST: Drivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverID,DriverRole,Name,ContractLength,TeamID,StrategyPlan,CarID")] Driver driver)
        {
            if (id != driver.DriverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverID))
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
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "CarID", driver.CarID);
            ViewData["TeamID"] = new SelectList(_context.Teams, "TeamID", "TeamID", driver.TeamID);
            return View(driver);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers
                .Include(d => d.Car)
                .Include(d => d.Team)
                .FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverID == id);
        }
#endif
    }
}
