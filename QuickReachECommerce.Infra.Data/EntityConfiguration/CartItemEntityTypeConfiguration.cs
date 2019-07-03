﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickReach.ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce.Infra.Data.EntityConfiguration
{
    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {

        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
        builder.ToTable("CartItem");
        builder.Property(c => c.Id)
               .IsRequired()
               .ValueGeneratedOnAdd();
        
        }
    }
}
