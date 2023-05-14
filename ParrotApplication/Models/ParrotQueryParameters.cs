using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotsApplication.Models
{
    public class ParrotQueryParameters
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Size { get; set; }    
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
