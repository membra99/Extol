using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
    public class ProductDetails
    {
        public int ProductDetailsId { get; set; }
        public string? General { get; set; }
        public string? TechnicalDetails { get; set; }
        public string? Design { get; set; }
        public string? AboutProduct { get; set; }
        public int? Draft { get; set; }
        public string? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ProfileId { get; set; }
        
        public Categories? Category { get; set; }
        public Profiles? Profile { get; set; }
        public Media? Media { get; set; }

    }
}
