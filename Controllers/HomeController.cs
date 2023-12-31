﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School43_ASP.NET.Data;
using School43_ASP.NET.Models;
using System.Diagnostics;

namespace School43_ASP.NET.Controllers
{
    public class HomeController : Controller
    {

        private readonly SchoolContext _context;

        public HomeController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            ViewData["News"] = await _context.News.OrderByDescending(n => n.Id).Take(5).ToListAsync();
            ViewData["Notify"] = await _context.Notifies.OrderByDescending(n => n.Id).Take(1).ToListAsync();

            return _context.News!= null ?
                        View():
                        Problem("Entity set 'SchoolContext.Home'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var rank = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
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

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var rank = await _context.News.FindAsync(id);
            if (rank == null)
            {
                return NotFound();
            }
            return View(rank);
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var rank = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rank == null)
            {
                return NotFound();
            }

            return View(rank);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'SchoolContext.Home'  is null.");
            }
            var rank = await _context.News.FindAsync(id);
            if (rank != null)
            {
                _context.News.Remove(rank);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankExists(int id)
        {
            return (_context.News?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}