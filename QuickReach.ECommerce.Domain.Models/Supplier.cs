﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickReach.ECommerce.Domain.Models
{
	[Table("Supplier")]
	public class Supplier : EntityBase
	{
		[Required]
		[MaxLength(40)]
		public string Name { get; set; }
		[Required]
		[MaxLength(255)]
		public string Description { get; set; }
		[Required]
		public bool IsActive { get; set; }
	}
}
