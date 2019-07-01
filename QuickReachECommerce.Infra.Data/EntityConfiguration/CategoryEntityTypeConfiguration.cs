﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickReach.ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce.Infra.Data.EntityConfiguration
{
	class CategoryEntityTypeConfiguration
		: IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");

			builder.Property(c => c.ID)
				   .IsRequired()
				   .ValueGeneratedOnAdd();

		}
	}
}
