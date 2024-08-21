using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class GlazingODTO
    {
        public int GlazingId { get; set; }
        public int LayerNum { get; set; }
        public string? GlazingName { get; set; }
        public int MediaId { get; set; }
        public string? mediaSRC { get; set; }
        public string? Code { get; set; }
    }
}
