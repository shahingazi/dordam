using System.Collections.Generic;

namespace PriceComparisonWeb.ViewModel
{
    public class SubDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }
}
