using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answer.Pos.Api.Models
{
    public class CartItem : Product
    {
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }
}
