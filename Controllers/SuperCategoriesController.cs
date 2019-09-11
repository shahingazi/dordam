using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.Models;

namespace PriceComparisonWeb.Views
{
    [Authorize (Roles = "Administrator")]
    public class SuperCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SuperCategories.ToListAsync());
        }

        // GET: SuperCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superCategory == null)
            {
                return NotFound();
            }

            return View(superCategory);
        }

        // GET: SuperCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,QueueNumber")] SuperCategory superCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superCategory);
        }

        // GET: SuperCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategories.FindAsync(id);
            if (superCategory == null)
            {
                return NotFound();
            }
            return View(superCategory);
        }

        // POST: SuperCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,QueueNumber")] SuperCategory superCategory)
        {
            if (id != superCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperCategoryExists(superCategory.Id))
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
            return View(superCategory);
        }

        // GET: SuperCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategory = await _context.SuperCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superCategory == null)
            {
                return NotFound();
            }

            return View(superCategory);
        }

        // POST: SuperCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superCategory = await _context.SuperCategories.FindAsync(id);
            _context.SuperCategories.Remove(superCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperCategoryExists(int id)
        {
            return _context.SuperCategories.Any(e => e.Id == id);
        }
    }
}
