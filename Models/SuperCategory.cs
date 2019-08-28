using System.Collections.Generic;

namespace PriceComparisonWeb.Models
{
    public class SuperCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QueueNumber { get; set; }       
        public virtual ICollection<SuperCategoryMappingCategory> SuperCategoryMappingCategories { get; set; }
    }
}
