﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
	public class TagODTO
	{
		public int TagId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public int? LanguageID { get; set; }
		public string? LanguageName { get; set; }
	}
}