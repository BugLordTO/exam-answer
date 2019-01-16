using Answer.Pos.Api;
using Answer.Pos.Api.Controllers;
using Answer.Pos.Api.Models;
using Answer.Pos.Api.Repositories;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Answer.Pos.Test
{
    public class LogicTest
    {
        public static IEnumerable<object[]> cases = new List<object[]>
        {
            new object[] { new Cart { Id = 1, TotalPrice = 10, Discount = 0, GrandTotalPrice = 10,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 1, TotalPrice = 10, },
                    },
                }, 0.0 },
            new object[] { new Cart { Id = 1, TotalPrice = 20, Discount = 0, GrandTotalPrice = 20,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 2, TotalPrice = 20, },
                    },
                }, 0.0 },
            new object[] { new Cart { Id = 1, TotalPrice = 40, Discount = 10, GrandTotalPrice = 30,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 4, TotalPrice = 40, },
                    },
                }, 10.0 },
            new object[] { new Cart { Id = 1, TotalPrice = 90, Discount = 20, GrandTotalPrice = 70,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 9, TotalPrice = 90, },
                    },
                }, 20.0 },
            new object[] { new Cart { Id = 1, TotalPrice = 90, Discount = 20, GrandTotalPrice = 70,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 9, TotalPrice = 90, },
                        new CartItem { Product = new Product { Id = 2, Name = "shampoo", UnitPrice = 15, }, Quantity = 1, TotalPrice = 90, },
                        new CartItem { Product = new Product { Id = 3, Name = "cream", UnitPrice = 17, }, Quantity = 8, TotalPrice = 90, },
                        new CartItem { Product = new Product { Id = 4, Name = "toothphase", UnitPrice = 30, }, Quantity = 5, TotalPrice = 90, },
                    },
                }, 84.0 },
        };

        [Theory]
        [MemberData(nameof(cases))]
        public void add_item_to_existing_cart(Cart cart, double expected)
        {
            var sut = new Logic();
            var actual = sut.CalculateCartDiscount(cart);
            actual.Should().Be(expected);
        }
    }
}
