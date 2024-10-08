﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.IDTO
{
	public class ProductIDTO
	{
		public int ProductId { get; set; }
		public int CategoriesId { get; set; }
		public int? DeclarationId { get; set; }
		public int? SeoId { get; set; }

		[Required]
		public string ProductName { get; set; }

		public double Price { get; set; }
		public bool IsOnSale { get; set; }
		public string? Description { get; set; }
		public string? Specification { get; set; }
		public bool Recommended { get; set; }
		public bool BestProduct { get; set; }

		[Required]
		public string ProductCode { get; set; }

		public DateTime? CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
		public bool? IsActive { get; set; } = true;
		public int? Quantity { get; set; } = 0;
		public string? FeatureImg { get; set; }
		public List<string>? GalleyImg { get; set; }

		public int? LanguageID { get; set; }
		public SaleIDTO? SaleIDTO { get; set; }
		public SeoIDTO? SeoIDTO { get; set; }
	}
}