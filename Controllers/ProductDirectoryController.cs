using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.ViewModel;

namespace PriceComparisonWeb.Controllers
{
    public class ProductDirectoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductDirectoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubDirectory(int id)
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

            return PartialView("SubDirectory", subDirectories);
        }
    }
}