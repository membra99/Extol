using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class DoorHandleODTO
    {
        public int DoorHandleId { get; set; }
        public int MaterialId { get; set; }
        public int? MediaId { get; set; }
        public string? mediaSRC { get; set; }
        public string? Code { get; set; }
    }
}
