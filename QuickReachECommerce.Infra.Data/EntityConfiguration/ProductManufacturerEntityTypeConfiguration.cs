using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickReach.ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce.Infra.Data.EntityConfiguration
{
    public class ProductManufacturerEntityTypeConfiguration : IEntityTypeConfiguration<ProductManufacturer>
    {
        public void Configure(EntityTypeBuilder<ProductManufacturer> builder)
        {
            builder.ToTable("ProductManufacturer");
            builder.HasKey(mp => new { mp.ManufacturerID, mp.ProductID });
            builder.HasOne(mp => mp.Manufacturer)
                   .WithMany(s => s.ProductManufacturers)
                   .HasForeignKey("ManufacturerID");
            builder.HasOne(mp => mp.Product)
                   .WithMany(s => s.ProductManufacturers)
                   .HasForeignKey("ProductID");
        }
    }
    
}
