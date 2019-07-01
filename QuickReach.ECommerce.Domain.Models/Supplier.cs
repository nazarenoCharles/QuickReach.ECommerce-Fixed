using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace QuickReach.ECommerce.Domain.Models
{
	[Table("Supplier")]
	public class Supplier : EntityBase
	{
        public Supplier()
        {
            this.ProductSuppliers = new List<ProductSupplier>();

        }
        [Required]
		[MaxLength(40)]
		public string Name { get; set; }
		[Required]
		[MaxLength(255)]
		public string Description { get; set; }
		[Required]
		public bool IsActive { get; set; }
        public IEnumerable<ProductSupplier> ProductSuppliers { get; set; }
        public ProductSupplier GetProduct(int productId)
        {
            return ((ICollection<ProductSupplier>)this.ProductSuppliers)
                    .FirstOrDefault(ps => ps.SupplierID == this.ID &&
                               ps.ProductID == productId);
        }
        public void AddProduct(int productId)
        {
            var productSupplier = new ProductSupplier()
            {
                SupplierID = this.ID,
                 ProductID = productId
            };
            
            ((ICollection<ProductSupplier>)this.ProductSuppliers).Add(productSupplier);
        }
        public void RemoveProduct(int productId)
        {
            var product = this.GetProduct(productId);
            ((ICollection<ProductSupplier>)this.ProductSuppliers).Remove(product);
        }
    }
}
