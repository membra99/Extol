using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
	public class OpeningStyle
	{
        public int OpeningStyleId { get; set; }
		public int CategoryTypeId { get; set; }
		public int? MediaId { get; set; }
		public string? Code { get; set; }

		public Media? Media { get; set; }
		public CategoryType? CategoryType { get; set; }

	}
}
