#define API
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab_65_Football_API.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace lab_67_MVC_Website_Football.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FootballDbContext _context;
        static Uri url = new Uri("https://localhost:44377/api/players/");
        public PlayersController(FootballDbContext context)
        {
            _context = context;
        }
#if API
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetDriverDataAsync();
                var players = JsonConvert.DeserializeObject<List<Player>>(jsonString);
                return View(players);
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
        public async Task<IActionResult> Details(int? id)
        {
            string jsonString = null;
            if (id == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url.ToString() + id);
                var player = JsonConvert.DeserializeObject<Player>(jsonString);
                if (player == null)
                {
                    return NotFound();
                }
                return View(player);
            }
        }


        public async Task<IActionResult> Create([Bind("PlayerID,PlayerName,AgentID,Age,Salary,ContractLength,OwnerID")] Player player)
        {
            
            if (ModelState.IsValid)
            {
                string playerAsJson = JsonConvert.SerializeObject(player);
                

            }

            return View(player);
        }

#else
        // GET: Players
        public async Task<IActionResult> Index()
        {
            var footballDbContext = _context.Players.Include(p => p.Agent).Include(p => p.Owner);
            return View(await footballDbContext.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Agent)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentName");
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,PlayerName,AgentID,Age,Salary,ContractLength,OwnerID")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentName", player.AgentID);
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", player.OwnerID);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentName", player.AgentID);
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", player.OwnerID);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerID,PlayerName,AgentID,Age,Salary,ContractLength,OwnerID")] Player player)
        {
            if (id != player.PlayerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayerID))
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
            ViewData["AgentID"] = new SelectList(_context.Agents, "AgentID", "AgentName", player.AgentID);
            ViewData["OwnerID"] = new SelectList(_context.Owners, "OwnerID", "OwnerID", player.OwnerID);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players
                .Include(p => p.Agent)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.PlayerID == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }
#endif
    }
}
