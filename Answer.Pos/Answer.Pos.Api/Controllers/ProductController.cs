using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Answer.Pos.Api.Models;
using Answer.Pos.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Answer.Pos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataRepository<Product> productRepository;

        public ProductController(
            DataRepository<Product> productRepository
            )
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            return Ok(productRepository.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return productRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody]ProductBase document)
        {
            productRepository.Create(new Product
            {
                Name = document.Name,
                UnitPrice = document.UnitPrice,
            });
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductBase document)
        {
            var product = productRepository.Get(id);
            if (product != null)
            {
                product.Name = document.Name;
                product.UnitPrice = document.UnitPrice;

                productRepository.Update(product);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
