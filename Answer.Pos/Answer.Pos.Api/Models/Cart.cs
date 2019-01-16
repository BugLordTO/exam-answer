using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public double GrandTotalPrice { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
    }
}
