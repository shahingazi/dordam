using System.Collections.Generic;

namespace PriceComparisonWeb.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
