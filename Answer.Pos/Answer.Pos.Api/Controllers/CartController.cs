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
    public class CartController : ControllerBase
    {
        private readonly DataRepository<Product> productRepository;
        private readonly DataRepository<Cart> cartRepository;

        public CartController(
            DataRepository<Product> productRepository,
            DataRepository<Cart> cartRepository
            )
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        [HttpGet]
        public Cart AddToCart([FromBody]AddItem item)
        {
            var cart = cartRepository.Get(0);
            if (item?.Quantity <= 0)
            {
                return cart;
            }

            //var product = pro

            if (cart == null)
            {
                cart = new Cart
                {
                    //TotalPrice =
                };
                cartRepository.Create(cart);
            }
            return cart;
        }
    }
}
