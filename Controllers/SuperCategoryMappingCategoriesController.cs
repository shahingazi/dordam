using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.Models;

namespace PriceComparisonWeb.Controllers
{
    [Authorize]
    public class SuperCategoryMappingCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperCategoryMappingCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperCategoryMappingCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SuperCategoryMappingCategories.Include(s => s.Category).Include(s => s.SuperCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SuperCategoryMappingCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategoryMappingCategory = await _context.SuperCategoryMappingCategories
                .Include(s => s.Category)
                .Include(s => s.SuperCategory)
                .FirstOrDefaultAsync(m => m.SuperCategoryId == id);
            if (superCategoryMappingCategory == null)
            {
                return NotFound();
            }

            return View(superCategoryMappingCategory);
        }

        // GET: SuperCategoryMappingCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["SuperCategoryId"] = new SelectList(_context.SuperCategories, "Id", "Name");
            return View();
        }

        // POST: SuperCategoryMappingCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperCategoryId,CategoryId")] SuperCategoryMappingCategory superCategoryMappingCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superCategoryMappingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", superCategoryMappingCategory.CategoryId);
            ViewData["SuperCategoryId"] = new SelectList(_context.SuperCategories, "Id", "Id", superCategoryMappingCategory.SuperCategoryId);
            return View(superCategoryMappingCategory);
        }

        // GET: SuperCategoryMappingCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategoryMappingCategory = await _context.SuperCategoryMappingCategories.FindAsync(id);
            if (superCategoryMappingCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", superCategoryMappingCategory.CategoryId);
            ViewData["SuperCategoryId"] = new SelectList(_context.SuperCategories, "Id", "Id", superCategoryMappingCategory.SuperCategoryId);
            return View(superCategoryMappingCategory);
        }

        // POST: SuperCategoryMappingCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuperCategoryId,CategoryId")] SuperCategoryMappingCategory superCategoryMappingCategory)
        {
            if (id != superCategoryMappingCategory.SuperCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superCategoryMappingCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperCategoryMappingCategoryExists(superCategoryMappingCategory.SuperCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", superCategoryMappingCategory.CategoryId);
            ViewData["SuperCategoryId"] = new SelectList(_context.SuperCategories, "Id", "Id", superCategoryMappingCategory.SuperCategoryId);
            return View(superCategoryMappingCategory);
        }

        // GET: SuperCategoryMappingCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superCategoryMappingCategory = await _context.SuperCategoryMappingCategories
                .Include(s => s.Category)
                .Include(s => s.SuperCategory)
                .FirstOrDefaultAsync(m => m.SuperCategoryId == id);
            if (superCategoryMappingCategory == null)
            {
                return NotFound();
            }

            return View(superCategoryMappingCategory);
        }

        // POST: SuperCategoryMappingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superCategoryMappingCategory = await _context.SuperCategoryMappingCategories.FindAsync(id);
            _context.SuperCategoryMappingCategories.Remove(superCategoryMappingCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperCategoryMappingCategoryExists(int id)
        {
            return _context.SuperCategoryMappingCategories.Any(e => e.SuperCategoryId == id);
        }
    }
}
