using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
	public class Brand
	{
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public ICollection<Profiles> Profiles { get; set; }
    }
}
