using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class CategoryTypesODTO
    {
        public int CategoryTypeId { get; set; }
        public int? MediaId { get; set; }
        public string? mediaSRC { get; set; }
        public int CategoryId { get; set; }
        public string? Code { get; set; }
    }
}
