namespace PriceComparisonWeb.Models
{
    public class EcommercePriceFile
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Product_name { get; set; }
        public string Manufacturer_Part_NumberMPN { get; set; }
        public string EAN { get; set; }
        public string Description { get; set; }
        public string Product_URL { get; set; }
        public string Image_URL { get; set; }
        public double Price_incl_VAT { get; set; }
        public double Shipping_cost { get; set; }
        public string Condition { get; set; }
        public string Stock_status { get; set; }
        public string Bundle { get; set; }
        public string Colour { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
    }   
}
