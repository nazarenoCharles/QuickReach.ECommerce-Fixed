﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickReach.ECommerce.Domain.Models
{
	[Table("Product")]
	public class Product : EntityBase
	{
		[Required]
		[MaxLength(40)]
		public string Name { get; set; }
		[Required]
		[MaxLength(255)]
		public string Description { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		public string ImageUrl { get; set; }

		public IEnumerable<ProductCategory> ProductCategories { get; set; }
	}
}
