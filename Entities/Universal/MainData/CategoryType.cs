using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
	public class CategoryType
	{
        public int CategoryTypeId { get; set; }
        public int? MediaId { get; set; }
        public int CategoryId { get; set; }
        public string? Code { get; set; }

        public Media? Media { get; set; }
        public Categories? Category { get; set; }
        public ICollection<OpeningStyle> OpeningStyles { get; set; }
    }
}
