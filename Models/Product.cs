using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string ManufacturerPartNumberMPN { get; set; }
        public string EAN { get; set; }
        public string Description { get; set; }
        public string Image_URL { get; set; }
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
