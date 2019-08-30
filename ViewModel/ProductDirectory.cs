using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceComparisonWeb.ViewModel
{
    public class ProductDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubDirectory> SubDirectories { get; set; }
    }

    public class SubDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



}
