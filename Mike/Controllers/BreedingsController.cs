using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mike.Data;
using Mike.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mike
{
    public class BreedingsController : Controller
    {
        private readonly MvcBreedingContext _context;

        public BreedingsController(MvcBreedingContext context)
        {
            _context = context;
        }

        // GET: Breedings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Breeding.ToListAsync());
        }

        // GET: Breedings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breeding = await _context.Breeding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breeding == null)
            {
                return NotFound();
            }

            return View(breeding);
        }

        // GET: Breedings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Breedings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DogRace,DogName,BirthDate")] Breeding breeding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breeding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breeding);
        }

        // GET: Breedings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breeding = await _context.Breeding.FindAsync(id);
            if (breeding == null)
            {
                return NotFound();
            }
            return View(breeding);
        }

        // POST: Breedings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DogRace,DogName,BirthDate")] Breeding breeding)
        {
            if (id != breeding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breeding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreedingExists(breeding.Id))
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
            return View(breeding);
        }

        // GET: Breedings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breeding = await _context.Breeding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (breeding == null)
            {
                return NotFound();
            }

            return View(breeding);
        }

        // POST: Breedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breeding = await _context.Breeding.FindAsync(id);
            _context.Breeding.Remove(breeding);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreedingExists(int id)
        {
            return _context.Breeding.Any(e => e.Id == id);
        }
    }
}
