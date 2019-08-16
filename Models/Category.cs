using System.Collections.Generic;

namespace PriceComparisonWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public virtual ICollection<SubCategory> SubCategory { get; set; }
        public virtual ICollection<SuperCategoryMappingCategory> SuperCategoryMappingCategories { get; set; }
    }
}
