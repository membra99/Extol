using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
    public class Types
    {
        public int TypeId { get; set; }
        public int ProfileId { get; set; }
        public int MediaId { get; set; }

        public Profiles Profile { get; set; }
        public Media Media { get; set; }
    }
}
