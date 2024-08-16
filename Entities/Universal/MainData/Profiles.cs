using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
    public class Profiles
    {
        public int ProfileId { get; set; }
        public int CategoryId { get; set; }
        public string? ProfileName { get; set; }
        public int MediaId { get; set; }
        public int MaterialId { get; set; }

        public Categories? Category { get; set; }
        public Media? Media { get; set; }
        public Materials? Material { get; set; }
        public ICollection<Types> Types { get; set; }
    }
}
