﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Universal.MainData
{
	public class Seo
	{
		public int SeoId { get; set; }
		public int? LanguageID { get; set; }
		public string? GoogleDesc { get; set; }
		public string? GoogleKeywords { get; set; }

		public Language? Language { get; set; }
		public ICollection<Product> Products { get; set; }
		public ICollection<Categories> Categories { get; set; }
		public ICollection<SiteContent> SiteContents { get; set; }
	}
}