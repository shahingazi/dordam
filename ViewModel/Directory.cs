using System.Collections.Generic;

namespace PriceComparisonWeb.ViewModel
{
    public class Directory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubDirectory> SubDirectories { get; set; }
    }
}
