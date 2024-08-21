using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class OpeningStyleODTO
    {
        public int OpeningStyleId { get; set; }
        public int CategoryTypeId { get; set; }
        public int? MediaId { get; set; }
        public string? mediaSRC { get; set; }
        public string? Code { get; set; }
    }
}
