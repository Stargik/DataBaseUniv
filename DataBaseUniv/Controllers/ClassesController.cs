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
    public class ClassesController : Controller
    {
        private readonly DataBaseUniv2Context _context;

        public ClassesController(DataBaseUniv2Context context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var dataBaseUniv2Context = _context.Classes.Include(c => c.Cource).Include(c => c.Teacher);
            return View(await dataBaseUniv2Context.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Cource)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["CourceId"] = new SelectList(_context.Cources, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,CourceId,Classroom")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourceId"] = new SelectList(_context.Cources, "Id", "Id", @class.CourceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["CourceId"] = new SelectList(_context.Cources, "Id", "Id", @class.CourceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", @class.TeacherId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,CourceId,Classroom")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            ViewData["CourceId"] = new SelectList(_context.Cources, "Id", "Id", @class.CourceId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", @class.TeacherId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Cource)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'DataBaseUniv2Context.Classes'  is null.");
            }
            var @class = await _context.Classes.FindAsync(id);
            if (@class != null)
            {
                _context.Classes.Remove(@class);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
          return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
