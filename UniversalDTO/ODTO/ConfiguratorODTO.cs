using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class ConfiguratorODTO
    {
        public List<ProfilesODTO>? ProfilesODTOs  { get; set; }
        public List<CategoryTypesODTO>? CategoryTypesODTOs  { get; set; }
        public List<OpeningStyleODTO>? OpeningStyleODTOs { get; set; }
        public List<MaterialColorODTO>? MaterialColorODTOs { get; set; }
        public List<DoorHandleODTO>? DoorHandleODTOs { get; set; }
        public List<GlazingODTO>? GlazingODTOs { get; set; }
    }
}
