using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace PriceComparisonWeb.Controllers
{
    //todo: refactor
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

        public int SupercategoryId { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }


        [Route("CL/{id}/{subcategoryname}")]
        public IActionResult Index(int id)
        {
            var subcategory = _context.SubCategories.Find(id);
            var category = _context.Categories.Find(subcategory.CategoryId);
            var superCategoryMapping = _context.SuperCategoryMappingCategories.FirstOrDefault(x => x.CategoryId == category.Id);
            var superCategory = _context.SuperCategories.Find(superCategoryMapping.SuperCategoryId);

            ViewBag.Subcategory = subcategory.Name;
            ViewBag.Category = category.Name;
            ViewBag.Supercategory = superCategory.Name;
            ViewBag.SupercategoryId = superCategory.Id;
            ViewBag.CategoryId = category.Id;
            ViewBag.SubcategoryId = subcategory.Id;
            return View();
        }

        [Route("t/{id}/{categoryname}")]
        public IActionResult CategoyList(int id, string categoryname)
        {
            var subcategory = _context.SubCategories.Where(x => x.CategoryId == id);
            var superCategoryMapping = _context.SuperCategoryMappingCategories.FirstOrDefault(x => x.CategoryId == id);
            var superCategory = _context.SuperCategories.Find(superCategoryMapping.SuperCategoryId);

            var result = new SubDirectory
            {
                Id = id,
                Name = categoryname,
                Items = subcategory.Select(x => new Item
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            ViewBag.Category = categoryname;
            ViewBag.Supercategory = superCategory.Name;
            ViewBag.SupercategoryId = superCategory.Id;
            ViewBag.CategoryId = id;
            return View(result);
        }

        [Route("d/{id}/{supercategoryname}")]
        public IActionResult SuperCategoyList(int id, string supercategoryname)
        {
            var categories = _context.SuperCategoryMappingCategories
                .Where(x => x.SuperCategoryId == id)
                .Include(x => x.Category)
                .ToList();

            var subDirectories = new List<SubDirectory>();

            foreach (var category in categories)
            {
                var subCategories = _context.SubCategories.Where(x => x.CategoryId == category.CategoryId).ToList();

                SubDirectory subDirectory = new SubDirectory
                {
                    Id = category.CategoryId,
                    Name = category.Category.Name,
                    Items = subCategories.Select(x => new Item
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                };
                subDirectories.Add(subDirectory);
            }

            ViewBag.Supercategory = supercategoryname;
            ViewBag.SupercategoryId = id;

            return View(subDirectories);
        }
    }
}