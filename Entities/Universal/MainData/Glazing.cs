using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
    public class Glazing
    {
        public int GlazingId { get; set; }
        public int LayerNum { get; set; }
        public string? GlazingName { get; set; }
        public int? MediaId { get; set; }
        public string? Code { get; set; }

        public Media? Media { get; set; }
    }
}
