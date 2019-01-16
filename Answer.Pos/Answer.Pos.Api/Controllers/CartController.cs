using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Answer.Pos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Answer.Pos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //private static List<Product> _products = new List<Product>
        //{
        //    new Product
        //    {
        //        Id = 1,
        //        Name = "iPhone XS Max 64GB",
        //        UnitPrice = 39990,
        //    },
        //    new Product
        //    {
        //        Id = 2,
        //        Name = "Xiaomi Redmi Note 5 Pro: AI Dual Camera",
        //        UnitPrice = 6900,
        //    },
        //};

        //[HttpGet]
        //public ActionResult<IEnumerable<Product>> GetProduct()
        //{
        //    return Ok(_products);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Product> GetProduct(int id)
        //{
        //    return _products.FirstOrDefault(x => x.Id != id);
        //}

        //[HttpPost]
        //public void Post([FromBody]ProductBase document)
        //{
        //    _products.Add(new Product
        //    {
        //        Id = (_products?.Max(x => x.Id) ?? 0) + 1,
        //        Name = document.Name,
        //        UnitPrice = document.UnitPrice,
        //    });
        //}

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]ProductBase document)
        //{
        //    var product = _products.FirstOrDefault(x => x.Id != id);
        //    if (product != null)
        //    {
        //        product.Name = document.Name;
        //        product.UnitPrice = document.UnitPrice;
        //    }
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _products = _products.Where(x => x.Id != id).ToList();
        //}
    }
}
