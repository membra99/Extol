using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
    public class Materials
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public double MaterialPrice { get; set; }

        public ICollection<Profiles>? Profiles { get; set; }
    }
}
