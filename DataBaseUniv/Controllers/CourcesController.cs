using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseUniv.Models;

namespace DataBaseUniv.Controllers
{
    public class CourcesController : Controller
    {
        private readonly DataBaseUniv2Context _context;

        public CourcesController(DataBaseUniv2Context context)
        {
            _context = context;
        }

        // GET: Cources
        public async Task<IActionResult> Index()
        {
            var dataBaseUniv2Context = _context.Cources.Include(c => c.Level);
            return View(await dataBaseUniv2Context.ToListAsync());
        }

        // GET: Cources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cources == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .Include(c => c.Level)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // GET: Cources/Create
        public IActionResult Create()
        {
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id");
            return View();
        }

        // POST: Cources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,LevelId")] Cource cource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", cource.LevelId);
            return View(cource);
        }

        // GET: Cources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cources == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources.FindAsync(id);
            if (cource == null)
            {
                return NotFound();
            }
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", cource.LevelId);
            return View(cource);
        }

        // POST: Cources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LevelId")] Cource cource)
        {
            if (id != cource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourceExists(cource.Id))
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
            ViewData["LevelId"] = new SelectList(_context.Levels, "Id", "Id", cource.LevelId);
            return View(cource);
        }

        // GET: Cources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cources == null)
            {
                return NotFound();
            }

            var cource = await _context.Cources
                .Include(c => c.Level)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // POST: Cources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cources == null)
            {
                return Problem("Entity set 'DataBaseUniv2Context.Cources'  is null.");
            }
            var cource = await _context.Cources.FindAsync(id);
            if (cource != null)
            {
                _context.Cources.Remove(cource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourceExists(int id)
        {
          return (_context.Cources?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
