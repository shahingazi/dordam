using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.ViewModel;
using System.Linq;

namespace PriceComparisonWeb.Controllers
{
    public class CLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CLController(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Supercategory { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }

        [Route("CL/{id}/{subcategoryname}")]
        public IActionResult Index(int id)
        {
            var subcategory = _context.SubCategories.Find(id);
            var category = _context.Categories.Find(subcategory.CategoryId);
            var superCategoryMapping = _context.SuperCategoryMappingCategories.FirstOrDefault(x => x.CategoryId == category.Id);
            var superCategory = _context.SubCategories.Find(superCategoryMapping.SuperCategoryId);
            ViewBag.Subcategory = subcategory.Name;
            ViewBag.Category = category.Name;
            ViewBag.Supercategory = superCategory.Name;
            return View();
        }


    }
}