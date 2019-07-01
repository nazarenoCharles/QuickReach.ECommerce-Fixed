using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickReach.ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce.Infra.Data.EntityConfiguration
{
    public class ProductSupplierEntityTypeConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {

            builder.ToTable("ProductSupplier");
            builder.HasKey(sp => new { sp.SupplierID, sp.ProductID });
            builder.HasOne(sp => sp.Supplier)
                   .WithMany(s => s.ProductSuppliers)
                   .HasForeignKey("SupplierID");
            builder.HasOne(sp => sp.Product)
                   .WithMany(s => s.ProductSuppliers)
                   .HasForeignKey("ProductID");
        }
    }

}
