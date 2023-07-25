using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School43_ASP.NET.Data;
using School43_ASP.NET.Models;

namespace School43_ASP.NET.Services
{
    public class RankServices : Controller
    {
        private readonly SchoolContext _context;

        public RankServices(SchoolContext context)
        {
            _context = context;
        }

        // GET: RankServices
        public async Task<IActionResult> Index()
        {
              return _context.Ranks != null ? 
                          View(await _context.Ranks.ToListAsync()) :
                          Problem("Entity set 'SchoolContext.Ranks'  is null.");
        }

        // GET: RankServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // GET: RankServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RankServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CreatedAt,UpdatedAt")] Rank rank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rank);
        }

        // GET: RankServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

        // POST: RankServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CreatedAt,UpdatedAt")] Rank rank)
        {
            if (id != rank.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankExists(rank.ID))
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
            return View(rank);
        }

        // GET: RankServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ranks == null)
            {
                return NotFound();
            }

            var rank = await _context.Ranks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // POST: RankServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ranks == null)
            {
                return Problem("Entity set 'SchoolContext.Ranks'  is null.");
            }
            var rank = await _context.Ranks.FindAsync(id);
            if (rank != null)
            {
                _context.Ranks.Remove(rank);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankExists(int id)
        {
          return (_context.Ranks?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
