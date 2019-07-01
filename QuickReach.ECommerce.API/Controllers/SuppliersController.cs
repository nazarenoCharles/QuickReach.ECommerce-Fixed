using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickReach.ECommerce.Domain;
using QuickReach.ECommerce.Domain.Models;
using QuickReachECommerce.Infra.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickReach.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository repository;
        private readonly IProductRepository productrepository;
        private readonly ECommerceDbContext context;
        public SuppliersController(ISupplierRepository repository, IProductRepository productrepository
            , ECommerceDbContext context)
        {
            this.repository = repository;
            this.productrepository = productrepository;
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get(string search = "", int skip = 0, int count = 10)
        {
            var supplier = repository.Retrieve(search, skip, count);

            return Ok(supplier);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var supplier = this.repository.Retrieve(id);
            return Ok(supplier);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Supplier supplier)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            this.repository.Create(supplier);

            return CreatedAtAction(nameof(this.Get), supplier);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var entity = this.repository.Retrieve(id);
            if (entity == null)
            {
                return NotFound();
            }

            this.repository.Update(id, supplier);

            return Ok(supplier);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok();
        }

        [HttpPost("{supplierId}/products")]
        public IActionResult AddProductSupplier(int supplierId, [FromBody] ProductSupplier entity)
        {
            var supplier = this.repository.Retrieve(supplierId);
            var product = productrepository.Retrieve(entity.ProductID);
            if (supplier == null)
            {
                return NotFound();
            }
            if (product == null)
            {
                return NotFound();  
            }

            supplier.AddProduct(entity.ProductID);
            repository.Update(supplierId, supplier);
            return Ok(supplier);
        }
    }
}
