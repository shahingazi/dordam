using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PriceComparisonWeb.Models
{
    public class SuperCategoryMappingCategory
    {
        [ForeignKey("SuperCategory")]
        public int SuperCategoryId { get; set; }
        public SuperCategory SuperCategory { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
