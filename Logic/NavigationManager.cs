using Microsoft.EntityFrameworkCore;
using PriceComparisonWeb.Data;
using PriceComparisonWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceComparisonWeb.Logic
{
    public class NavigationManager
    {
        private readonly ApplicationDbContext _context;

        public NavigationManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperCategory>> GetSuperCategories()
        {
            return await _context.SuperCategories.ToListAsync();
        }

    }
}
