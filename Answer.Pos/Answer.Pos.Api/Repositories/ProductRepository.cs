using Answer.Pos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api.Repositories
{
    public class ProductRepository<T> : DataRepository<T>
        where T : Product
    {
        private static int _lastId = 2;

        private static List<T> _products = new List<T>
        {
            (T)new Product
            {
                Id = 1,
                Name = "iPhone XS Max 64GB",
                UnitPrice = 39990,
            },
            (T)new Product
            {
                Id = 2,
                Name = "Xiaomi Redmi Note 5 Pro: AI Dual Camera",
                UnitPrice = 6900,
            },
        };

        public IEnumerable<T> Get()
        {
            return _products;
        }

        public T Get(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T document)
        {
            document.Id = ++_lastId;
            _products.Add(document);
        }

        public void Update(T document)
        {
            var product = _products.FirstOrDefault(x => x.Id == document.Id);
            if (product != null)
            {
                product.Name = document.Name;
                product.UnitPrice = document.UnitPrice;
            }
        }

        public void Delete(int id)
        {
            _products = _products.Where(x => x.Id != id).ToList();
        }
    }
}
