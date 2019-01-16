using Answer.Pos.Api.Controllers;
using Answer.Pos.Api.Models;
using Answer.Pos.Api.Repositories;
using FluentAssertions;
using FluentAssertions.Equivalency;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Answer.Pos.Test
{
    public class CartTest
    {
        public Mock<DataRepository<Product>> productRepository { get; set; }
        public Mock<DataRepository<Cart>> cartRepository { get; set; }

        public CartController cartController { get; set; }

        public CartTest()
        {
            var mock = new MockRepository(MockBehavior.Strict);
            productRepository = mock.Create<DataRepository<Product>>();
            cartRepository = mock.Create<DataRepository<Cart>>();

            productRepository.Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns<int>(id => new Product { Id = 1, Name = "soap", UnitPrice = 10, });

            cartController = new CartController(productRepository.Object, cartRepository.Object);

            AssertionOptions.AssertEquivalencyUsing(options =>
            {
                options.WithoutStrictOrdering();
                return options;
            });
        }

        public static IEnumerable<object[]> addToCartCases = new List<object[]>
        {
            new object[] { new AddItem { ProductId = 99, Quantity = 1 }, new Cart { Id = 1, TotalPrice = 10, Discount = 0, GrandTotalPrice = 10,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 1, TotalPrice = 10, }
                    },
                }},
            new object[] { new AddItem { ProductId = 1, Quantity = 0 }, new Cart { Id = 1, TotalPrice = 10, Discount = 0, GrandTotalPrice = 10,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 1, TotalPrice = 10, }
                    },
                }},
            new object[] { new AddItem { ProductId = 1, Quantity = -1 }, new Cart { Id = 1, TotalPrice = 10, Discount = 0, GrandTotalPrice = 10,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 1, TotalPrice = 10, }
                    },
                }},
            new object[] { new AddItem { ProductId = 1, Quantity = 1 }, new Cart { Id = 1, TotalPrice = 20, Discount = 0, GrandTotalPrice = 20,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 2, TotalPrice = 20, }
                    },
                }},
            new object[] { new AddItem { ProductId = 1, Quantity = 3 }, new Cart { Id = 1, TotalPrice = 40, Discount = 10, GrandTotalPrice = 30,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 4, TotalPrice = 40, }
                    },
                }},
            new object[] { new AddItem { ProductId = 1, Quantity = 8 }, new Cart { Id = 1, TotalPrice = 90, Discount = 20, GrandTotalPrice = 70,
                    Items = new List<CartItem>
                    {
                        new CartItem { Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, }, Quantity = 9, TotalPrice = 90, }
                    },
                }},
        };
        /// <summary>
        /// add not exist item to existing 1 item cart will not change
        /// add item with 0 quantity to existing 1 item cart will not change
        /// add item with negative quantity to existing 1 item cart will not change
        /// add 1 item to existing 1 item cart will calculate total but not discount
        /// add 3 item to existing 1 item cart will calculate total and discount 1 item
        /// add 8 item to existing 1 item cart will calculate total and discount 2 item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(addToCartCases))]
        public void add_item_to_existing_cart(AddItem item, Cart expected)
        {
            cartRepository.Setup(repo => repo.Get(It.IsAny<int>()))
                .Returns<int>(id => new Cart
                {
                    Id = 1,
                    TotalPrice = 10,
                    Discount = 0,
                    GrandTotalPrice = 10,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Product = new Product { Id = 1, Name = "soap", UnitPrice = 10, },
                            Quantity = 1,
                            TotalPrice = 10,
                        }
                    },
                });

            var cart = cartController.AddToCart(item);

            //var defaultAssertionOptions = EquivalencyAssertionOptions<Cart>.Default;
            //EquivalencyAssertionOptions<Cart>.Default = () =>
            //{
            //    var config = defaultAssertionOptions();
            //    config.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation)).WhenTypeIs<DateTime>();
            //    return config;
            //};
            cart.Should().BeEquivalentTo(expected);
        }

        //add_not_exist_item_to_empty_cart_will_not_change
        //add_item_with_0_or_negative_quantity_to_empty_cart_will_not_change
        //add_1_item_to_empty_cart_will_calculate_total_but_not_discount
        //add_4_item_to_existing_1_item_cart_will_calculate_total_and_discount_1_item
        //add_9_item_to_existing_1_item_cart_will_calculate_total_and_discount_2_item

        /*
         
         add not exist item to empty cart will not change
         add item with 0 or negative quantity to empty cart will not change
         add 1 item to empty cart will calculate total but not discount
         add 4 item to existing 1 item cart will calculate total and discount 1 item
         add 9 item to existing 1 item cart will calculate total and discount 2 item
         */
    }
}
