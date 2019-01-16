using Answer.Pos.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api.Repositories
{
    public class CartRepository<T> : DataRepository<T>
        where T : Cart
    {
        private static int _lastId = 0;

        private static List<T> _carts = new List<T>();

        public IEnumerable<T> Get()
        {
            return _carts;
        }

        public T Get(int id)
        {
            return _carts.FirstOrDefault();
        }

        public void Create(T document)
        {
            document.Id = ++_lastId;
            _carts.Add(document);
        }

        public void Update(T document)
        {
            var cart = _carts.FirstOrDefault(x => x.Id == document.Id);
            if (cart != null)
            {
                cart.TotalPrice = document.TotalPrice;
                cart.Discount = document.Discount;
                cart.GrandTotalPrice = document.GrandTotalPrice;
                cart.Items = document.Items;
            }
        }

        public void Delete(int id)
        {
            _carts = _carts.Where(x => x.Id != id).ToList();
        }
    }
}
