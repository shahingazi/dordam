using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.Models;

namespace PriceComparisonWeb.Controllers
{
    public class EcommercePriceFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EcommercePriceFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EcommercePriceFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.EcommercePriceFile.ToListAsync());
        }

        // GET: EcommercePriceFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecommercePriceFile = await _context.EcommercePriceFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecommercePriceFile == null)
            {
                return NotFound();
            }

            return View(ecommercePriceFile);
        }

        // GET: EcommercePriceFiles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EcommercePriceFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Category,Brand,Product_name,Manufacturer_Part_NumberMPN,EAN,Description,Product_URL,Image_URL,Price_incl_VAT,Shipping_cost,Condition,Stock_status,Bundle,Colour,Gender,Size")] EcommercePriceFile ecommercePriceFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecommercePriceFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ecommercePriceFile);
        }

        // GET: EcommercePriceFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecommercePriceFile = await _context.EcommercePriceFile.FindAsync(id);
            if (ecommercePriceFile == null)
            {
                return NotFound();
            }
            return View(ecommercePriceFile);
        }

        // POST: EcommercePriceFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Brand,Product_name,Manufacturer_Part_NumberMPN,EAN,Description,Product_URL,Image_URL,Price_incl_VAT,Shipping_cost,Condition,Stock_status,Bundle,Colour,Gender,Size")] EcommercePriceFile ecommercePriceFile)
        {
            if (id != ecommercePriceFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecommercePriceFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcommercePriceFileExists(ecommercePriceFile.Id))
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
            return View(ecommercePriceFile);
        }

        // GET: EcommercePriceFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecommercePriceFile = await _context.EcommercePriceFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecommercePriceFile == null)
            {
                return NotFound();
            }

            return View(ecommercePriceFile);
        }

        // POST: EcommercePriceFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ecommercePriceFile = await _context.EcommercePriceFile.FindAsync(id);
            _context.EcommercePriceFile.Remove(ecommercePriceFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcommercePriceFileExists(int id)
        {
            return _context.EcommercePriceFile.Any(e => e.Id == id);
        }
    }
}
