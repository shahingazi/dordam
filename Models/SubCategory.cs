using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonWeb.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
