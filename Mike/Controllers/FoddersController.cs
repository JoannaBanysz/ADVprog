using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mike.Data;
using Mike.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mike
{
    public class FoddersController : Controller
    {
        private readonly MvcFodderContext _context;

        public FoddersController(MvcFodderContext context)
        {
            _context = context;
        }

        // GET: Fodders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fodder.ToListAsync());
        }

        // GET: Fodders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fodder = await _context.Fodder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fodder == null)
            {
                return NotFound();
            }

            return View(fodder);
        }

        // GET: Fodders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fodders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producer,Name,ProductionDate,Price")] Fodder fodder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fodder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fodder);
        }

        // GET: Fodders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fodder = await _context.Fodder.FindAsync(id);
            if (fodder == null)
            {
                return NotFound();
            }
            return View(fodder);
        }

        // POST: Fodders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producer,Name,ProductionDate,Price")] Fodder fodder)
        {
            if (id != fodder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fodder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FodderExists(fodder.Id))
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
            return View(fodder);
        }

        // GET: Fodders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fodder = await _context.Fodder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fodder == null)
            {
                return NotFound();
            }

            return View(fodder);
        }

        // POST: Fodders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fodder = await _context.Fodder.FindAsync(id);
            _context.Fodder.Remove(fodder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FodderExists(int id)
        {
            return _context.Fodder.Any(e => e.Id == id);
        }
    }
}
