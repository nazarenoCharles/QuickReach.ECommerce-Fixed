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
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository repository;
        private readonly ECommerceDbContext context;
        private readonly IProductRepository productRepository;
        public CartsController(ICartRepository repository, ECommerceDbContext context, IProductRepository productRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.context = context;
        }
        // GET api/categories/5
        [HttpGet]
        public ActionResult Get()
        {
            var cart = this.repository.Retrieve();
            return Ok(cart);
        }
        [HttpGet("{Id}")]
        public ActionResult Get(int id)
        {
            var cart = this.repository.Retrieve(id);
            return Ok(cart);
        }
        [HttpPost("{Id}")]
        public IActionResult Post([FromBody] Cart cart)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            this.repository.Create(cart);

            return CreatedAtAction(nameof(this.Get), new { id = cart }, cart);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok();
        }
        //public IActionResult DeleteCartProduct(int id, int productId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    var cart = repository.Retrieve(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
        //    if (productRepository.Retrieve(productId) == null)
        //    {
        //        return NotFound();
        //    }
        //    cart.AddCart(productId);
        //    repository.Update(id, category);
        //    return Ok();
        //}

    }
}