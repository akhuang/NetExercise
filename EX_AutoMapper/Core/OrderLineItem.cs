using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class OrderLineItem
    {
        public Product ProductInfo { get; private set; }
        public int Quantity { get; private set; }
        public OrderLineItem(Product product, int quantity)
        {
            ProductInfo = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Quantity * ProductInfo.Price;
        }
    }
}
