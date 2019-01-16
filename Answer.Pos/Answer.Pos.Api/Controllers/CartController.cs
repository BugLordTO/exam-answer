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
        private readonly Logic logic;

        public CartController(
            DataRepository<Product> productRepository,
            DataRepository<Cart> cartRepository,
            Logic logic
            )
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.logic = logic;
        }

        [HttpGet]
        public Cart Get()
        {
            return cartRepository.Get(0);
        }

        [HttpPost]
        public Cart AddToCart([FromBody]AddItem item)
        {
            var cart = cartRepository.Get(0);
            if (cart == null)
            {
                cart = new Cart();
                cartRepository.Create(cart);
            }

            if (item?.Quantity <= 0)
            {
                return cart;
            }

            var product = productRepository.Get(item?.ProductId ?? 0);
            if (product == null)
            {
                return cart;
            }

            var cartItems = cart.Items.ToList();
            var cartItem = cartItems.FirstOrDefault(x => x.Product.Id == item.ProductId);
            if (cartItem == null)
            {
                cartItem = logic.BuildCartItem(product, item.Quantity);
                cartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += item.Quantity;
                cartItem.TotalPrice = logic.CalculateItemTotalPrice(product.UnitPrice, cartItem.Quantity);
            }

            cart.Items = cartItems;

            cart.TotalPrice = logic.CalculateCartTotalPrice(cart);
            cart.Discount = logic.CalculateCartDiscount(cart);
            cart.GrandTotalPrice = logic.CalculateCartGrandTotalPrice(cart);

            return cart;
        }
    }
}
