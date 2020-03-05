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
    public class AgentsController : Controller
    {
        private readonly FootballDbContext _context;
        static Uri url = new Uri("https://localhost:44377/api/agents/");
        public AgentsController(FootballDbContext context)
        {
            _context = context;
        }
#if API
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetAgentDataAsync();
                var agents = JsonConvert.DeserializeObject<List<Agent>>(jsonString);
                return View(agents);
            }
        }
        static async Task<string> GetAgentDataAsync()
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
            if(id == null)
            {
                return NotFound();
            }
            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url.ToString() + id);
                var agent = JsonConvert.DeserializeObject<Agent>(jsonString);
                if(agent == null)
                {
                    return NotFound();
                }
                return View(agent);
            }
        }
#else
        // GET: Agents
        public async Task<IActionResult> Index()
        {
            var footballDbContext = _context.Agents.Include(a => a.HeadStaff);
            return View(await footballDbContext.ToListAsync());
        }

        // GET: Agents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .Include(a => a.HeadStaff)
                .FirstOrDefaultAsync(m => m.AgentID == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        public IActionResult Create()
        {
            ViewData["HeadStaffID"] = new SelectList(_context.HeadStaffs, "HeadStaffID", "HeadStaffID");
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgentID,AgentName,HeadStaffID,AgentFee,PercentOwned")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HeadStaffID"] = new SelectList(_context.HeadStaffs, "HeadStaffID", "HeadStaffID", agent.HeadStaffID);
            return View(agent);
        }

        // GET: Agents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            ViewData["HeadStaffID"] = new SelectList(_context.HeadStaffs, "HeadStaffID", "HeadStaffID", agent.HeadStaffID);
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgentID,AgentName,HeadStaffID,AgentFee,PercentOwned")] Agent agent)
        {
            if (id != agent.AgentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.AgentID))
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
            ViewData["HeadStaffID"] = new SelectList(_context.HeadStaffs, "HeadStaffID", "HeadStaffID", agent.HeadStaffID);
            return View(agent);
        }

        // GET: Agents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .Include(a => a.HeadStaff)
                .FirstOrDefaultAsync(m => m.AgentID == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id)
        {
            return _context.Agents.Any(e => e.AgentID == id);
        }
#endif
    }
}
