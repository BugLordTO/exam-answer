using Answer.Pos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api
{
    public class Logic
    {
        public CartItem BuildCartItem(Product product, int quantity)
        {
            return new CartItem
            {
                Product = product,
                Quantity = quantity,
                TotalPrice = CalculateItemTotalPrice(product.UnitPrice, quantity),
            };
        }

        public double CalculateItemTotalPrice(double unitPrice, int quantity)
        {
            return unitPrice * quantity;
        }

        public double CalculateCartTotalPrice(Cart cart)
        {
            return cart?.Items?.Sum(x => x.TotalPrice) ?? 0;
        }

        public double CalculateCartDiscount(Cart cart)
        {
            const int ItemAmountToDiscount = 4;
            if (cart?.Items?.Count() == 0)
            {
                return 0;
            }

            var totalDiscount = 0.0;
            var discountingItems = cart.Items.Where(x => x.Quantity >= ItemAmountToDiscount);
            foreach (var item in discountingItems)
            {
                var discountTimes = item.Quantity / ItemAmountToDiscount;
                if (discountTimes > 0)
                {
                    var itemDiscount = discountTimes * item.Product.UnitPrice;
                    totalDiscount += itemDiscount;
                }
            }

            return totalDiscount;
        }

        public double CalculateCartGrandTotalPrice(Cart cart)
        {
            return cart.TotalPrice - cart.Discount;
        }
    }
}
