using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickReach.ECommerce.Domain;
using QuickReach.ECommerce.Domain.Models;
using QuickReachECommerce.Infra.Data;

namespace QuickReach.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerRepository repository;
        private readonly IProductRepository productRepo;
        private readonly ECommerceDbContext context;

        public ActionResult Get(string search = "", int skip = 0, int count = 10)
        {
            var supplier = repository.Retrieve(search, skip, count);

            return Ok(supplier);
        }
        public ActionResult Get(int id)
        {
            var manufacturer = this.repository.Retrieve(id);
            return Ok(manufacturer);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Manufacturer manufacturer)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this);
            }

            this.repository.Create(manufacturer);

            return CreatedAtAction(nameof(this.Get), manufacturer);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this);
            }

            var entity = this.repository.Retrieve(id);
            if (entity == null)
            {
                return NotFound(this);
            }

            this.repository.Update(id, manufacturer);

            return Ok(manufacturer);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok();
        }

    }
}