using System.ComponentModel.DataAnnotations.Schema;

namespace PriceComparisonWeb.Models
{
    public class ProductStock
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public double PriceInclVAT { get; set; }
        public double ShippingCost { get; set; }
        //public string Condition { get; set; }
        public string StockStatus { get; set; }
        public string Bundle { get; set; }
        public string Colour { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }        
        public double Rating { get; set; }
        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
