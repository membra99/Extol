using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class MaterialColorODTO
    {
        public int MaterialColorId { get; set; }
        public int MaterialId { get; set; }
        public string? Value { get; set; }
        public bool IsSpecial { get; set; }
        public int? Price { get; set; }
    }
}
